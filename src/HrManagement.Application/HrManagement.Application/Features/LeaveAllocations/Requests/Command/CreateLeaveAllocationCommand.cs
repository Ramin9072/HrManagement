using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;
using MediatR;

namespace HrManagement.Application.Features.LeaveAllocations.Requests.Command
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public ILeaveAllocationDto ILeaveAllocationDto { get; set; }
    }
}
