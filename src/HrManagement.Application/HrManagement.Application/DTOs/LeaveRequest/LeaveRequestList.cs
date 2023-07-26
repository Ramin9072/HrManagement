using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveType;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestList : BaseDTO
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }
    }
}
