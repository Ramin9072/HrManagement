using HrManagement.Application.DTOs.Common;

namespace HrManagement.Application.DTOs.LeaveType
{
    public class LeaveTypeDto : BaseDTO
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
