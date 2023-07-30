using System;

namespace HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto
{
    public interface ICreateLeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComment { get; set; }
    }
}
