using MediatR;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Command
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
