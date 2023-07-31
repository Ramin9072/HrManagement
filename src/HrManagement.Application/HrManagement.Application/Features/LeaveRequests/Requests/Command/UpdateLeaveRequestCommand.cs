using HrManagement.Application.DTOs.LeaveRequest.DTO;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using MediatR;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Command
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto UpdateLeaveRequestDTO { get; set; }
        public ChangeLeaveRequestApprovedDTO ChangeLeaveRequestApprovedDTO { get; set; }
        public ILeaveRequestDto ILeaveRequestDTO { get; set; }
    }
}
