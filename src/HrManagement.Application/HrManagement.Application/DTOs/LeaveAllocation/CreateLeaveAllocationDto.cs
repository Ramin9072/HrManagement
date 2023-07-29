using HrManagement.Application.DTOs.Common;

namespace HrManagement.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto : BaseDTO
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
