﻿using FluentValidation;
using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;
using HrManagement.Application.DTOs.LeaveAllocation.Validation.Abstraction;
using HrManagement.Application.Persistence.Contracts;

namespace HrManagement.Application.DTOs.LeaveAllocation.Validation
{
    public class CreateLeaveAllocationValidation : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationValidation(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationValidation(_leaveTypeRepository));
        }
    }
}
