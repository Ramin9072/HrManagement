using HrManagement.Application.DTOs.LeaveType.DTO.AbstractionDto;

namespace HrManagement.Application.DTOs.LeaveType.DTO
{
    public class CreateLeaveTypeDto : ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
