using HrManagement.Application.DTOs.LeaveRequest.DTO;
using MediatR;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailsRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
