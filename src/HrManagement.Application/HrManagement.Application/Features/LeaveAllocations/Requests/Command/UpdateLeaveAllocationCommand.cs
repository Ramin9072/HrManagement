using HrManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HrManagement.Application.Features.LeaveAllocations.Requests.Command
{
    public class UpdateLeaveAllocationCommand : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }
    }
}
