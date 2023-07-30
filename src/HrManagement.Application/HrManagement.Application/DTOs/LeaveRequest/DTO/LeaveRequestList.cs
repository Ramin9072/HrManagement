using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using HrManagement.Application.DTOs.LeaveType.DTO;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest.DTO
{
    public class LeaveRequestList : BaseDTO, ILeaveRequestList
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
