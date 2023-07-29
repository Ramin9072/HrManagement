using HrManagement.Application.DTOs.Common;

namespace HrManagement.Application.DTOs.LeaveType
{
    public class UpdateLeaveTypeDto : BaseDTO
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
