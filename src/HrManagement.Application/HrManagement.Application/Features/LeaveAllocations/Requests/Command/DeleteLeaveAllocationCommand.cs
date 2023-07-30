using HrManagement.Application.DTOs.LeaveAllocation.DTO;
using MediatR;

namespace HrManagement.Application.Features.LeaveAllocations.Requests.Command
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public DeleteLeaveAllocationDto DeleteLeaveAllocationDto { get; set; }
    }
}
