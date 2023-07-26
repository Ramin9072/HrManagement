using HrManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HrManagement.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {

        public int Id { get; set; }
    }
}
