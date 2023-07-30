using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;
using HrManagement.Application.DTOs.LeaveType.DTO;

namespace HrManagement.Application.DTOs.LeaveAllocation.DTO
{
    public class LeaveAllocationDto : BaseDTO, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
