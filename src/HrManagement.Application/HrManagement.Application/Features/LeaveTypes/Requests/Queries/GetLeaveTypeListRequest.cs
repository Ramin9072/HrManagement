using HrManagement.Application.DTOs.LeaveType;
using MediatR;
using System.Collections.Generic;

namespace HrManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
