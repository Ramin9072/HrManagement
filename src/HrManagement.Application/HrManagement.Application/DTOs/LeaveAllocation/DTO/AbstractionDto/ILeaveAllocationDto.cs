using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveType.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto
{
    public interface ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
