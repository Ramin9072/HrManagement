using HrManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HrManagement.Application.Features.LeaveAllocations.Requests.Command
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public DeleteLeaveAllocationDto DeleteLeaveAllocationDto { get; set; }
    }
}
