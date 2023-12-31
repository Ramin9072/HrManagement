﻿using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveAllocation.Validation;
using HrManagement.Application.Exceptions;
using HrManagement.Application.Features.LeaveAllocations.Requests.Command;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveAllocations.Handlers.Command
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validation = new UpdateLeaveAllocationValidation(_leaveTypeRepository);
            var validationResult = await validation.ValidateAsync(request.LeaveAllocationDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            #endregion

            var allocation = await _leaveAllocationRepository.GetById(request.LeaveAllocationDto.Id);
            _mapper.Map(request.LeaveAllocationDto, allocation);
            await _leaveAllocationRepository.Update(allocation);

            return Unit.Value;
        }
    }
}
