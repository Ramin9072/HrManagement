using HrManagement.Application.DTOs.LeaveType.DTO;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto
{
    public interface ILeaveRequestList
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
