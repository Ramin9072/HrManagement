using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveType;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDTO : BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComment { get; set; }
    }
}
