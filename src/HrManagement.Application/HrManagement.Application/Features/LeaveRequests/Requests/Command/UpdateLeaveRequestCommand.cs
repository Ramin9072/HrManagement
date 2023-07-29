using HrManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Command
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto UpdateLeaveRequestDTO { get; set; }
        public ChangeLeaveRequestApprovedDTO ChangeLeaveRequestApprovedDTO { get; set; }
    }
}
