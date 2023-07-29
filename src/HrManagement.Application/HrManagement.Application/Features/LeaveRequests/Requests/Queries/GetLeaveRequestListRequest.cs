using HrManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System.Collections.Generic;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestDto>>
    {

    }
}
