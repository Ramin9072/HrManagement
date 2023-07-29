using HrManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Command
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public CreateLeaveRequestDTO CreateLeaveRequestDTO { get; set; }
    }
}
