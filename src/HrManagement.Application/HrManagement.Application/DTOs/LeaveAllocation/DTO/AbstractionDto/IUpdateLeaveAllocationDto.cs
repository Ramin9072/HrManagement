namespace HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto
{
    public interface IUpdateLeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
