using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;

namespace HrManagement.Application.DTOs.LeaveAllocation.DTO
{
    public class UpdateLeaveAllocationDto : BaseDTO, IUpdateLeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
