﻿using HrManagement.Application.DTOs.LeaveAllocation;
using HrManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HrManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit> // no content اگر نداشته باشیم یا خالی باشد
    {
        public UpdateLeaveAllocationDto LeaveTypeDto { get; set; }
    }
}
