using HrManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Text;

namespace HrManagement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestDetailsRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
