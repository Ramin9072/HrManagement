using HrManagement.Application.DTOs.LeaveAllocation.DTO;
using MediatR;
using System.Collections.Generic;

namespace HrManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationDto>>
    {
    }
}
