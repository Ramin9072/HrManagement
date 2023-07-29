﻿using AutoMapper;
using FluentValidation;
using HrManagement.Application.DTOs.LeaveType.Validations;
using HrManagement.Application.Features.LeaveTypes.Requests.Commands;
using HrManagement.Application.Persistence.Contracts;
using HrManagement.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion

            var leaveTypeMap = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            var leavetypeSaved = await _leaveTypeRepository.Add(leaveTypeMap);
            return leavetypeSaved.Id;
        }
    }
}
