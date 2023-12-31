﻿using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;
using MediatR;

namespace HrManagement.Application.Features.LeaveAllocations.Requests.Command
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public ILeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
