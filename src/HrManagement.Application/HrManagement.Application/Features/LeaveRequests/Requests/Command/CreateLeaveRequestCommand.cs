using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using MediatR;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Command
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public ILeaveRequestDto ILeaveRequestDTO { get; set; }
    }
}
