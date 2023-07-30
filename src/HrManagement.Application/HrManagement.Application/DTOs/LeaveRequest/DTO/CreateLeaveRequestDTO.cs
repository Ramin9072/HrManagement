using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest.DTO
{
    public class CreateLeaveRequestDTO : BaseDTO, ICreateLeaveRequestDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComment { get; set; }
    }
}
