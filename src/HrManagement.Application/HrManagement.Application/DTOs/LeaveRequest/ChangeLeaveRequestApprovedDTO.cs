using HrManagement.Application.DTOs.Common;

namespace HrManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovedDTO : BaseDTO
    {
        public bool? Approved { get; set; }
    }
}
