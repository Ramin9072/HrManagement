namespace HrManagement.Application.DTOs.LeaveType.DTO.AbstractionDto
{
    public interface ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
