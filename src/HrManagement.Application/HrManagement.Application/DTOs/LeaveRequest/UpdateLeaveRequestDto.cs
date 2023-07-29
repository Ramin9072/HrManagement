using HrManagement.Application.DTOs.Common;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest
{
    public class UpdateLeaveRequestDto : BaseDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComment { get; set; }
        public bool Canceled { get; set; }
    }
}
