using HrManagement.Application.DTOs.LeaveAllocation.DTO;
using MediatR;

namespace HrManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
