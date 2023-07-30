using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using HrManagement.Application.DTOs.LeaveType.DTO;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest.DTO
{
    public class LeaveRequestDto : BaseDTO, ILeaveRequestDto
    {

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComment { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Canceled { get; set; }
    }
}
