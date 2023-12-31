﻿using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveAllocation.Validation;
using HrManagement.Application.Exceptions;
using HrManagement.Application.Features.LeaveAllocations.Requests.Command;
using HrManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveAllocations.Handlers.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validate = new CreateLeaveAllocationValidation(_leaveTypeRepository);
            var validationResult = await validate.ValidateAsync(request.ILeaveAllocationDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            #endregion

            var leaveAllocationMapped = _mapper.Map<LeaveAllocation>(request.ILeaveAllocationDto);
            var leaveAllocationOut = await _leaveAllocationRepository.Add(leaveAllocationMapped);
            return leaveAllocationOut.Id;
        }
    }
}
