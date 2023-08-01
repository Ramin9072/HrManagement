using HrManagement.Application.DTOs.LeaveType.DTO;
using HrManagement.Application.Responses;
using MediatR;

namespace HrManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
