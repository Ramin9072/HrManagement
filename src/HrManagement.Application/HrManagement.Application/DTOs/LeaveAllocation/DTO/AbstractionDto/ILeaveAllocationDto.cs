using HrManagement.Application.DTOs.LeaveType.DTO;

namespace HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto
{
    public interface ILeaveAllocationDto
    {
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
