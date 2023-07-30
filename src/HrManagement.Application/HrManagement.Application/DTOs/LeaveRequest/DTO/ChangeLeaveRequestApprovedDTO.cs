using HrManagement.Application.DTOs.Common;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;

namespace HrManagement.Application.DTOs.LeaveRequest.DTO
{
    public class ChangeLeaveRequestApprovedDTO : BaseDTO, IChangeLeaveRequestApprovedDTO
    {
        public bool? Approved { get; set; }
    }
}
