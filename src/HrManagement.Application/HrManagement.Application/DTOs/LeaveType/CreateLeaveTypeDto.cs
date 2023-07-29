using HrManagement.Application.DTOs.Common;

namespace HrManagement.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto : BaseDTO
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
