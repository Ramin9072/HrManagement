using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveType;

namespace HrManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
