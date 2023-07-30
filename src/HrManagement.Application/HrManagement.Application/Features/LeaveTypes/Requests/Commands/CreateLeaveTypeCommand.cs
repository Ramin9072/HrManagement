using HrManagement.Application.DTOs.LeaveType.DTO;
using MediatR;

namespace HrManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<int>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
