using HrManagement.Application.DTOs.LeaveType.DTO;
using MediatR;

namespace HrManagement.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateLeaveTypeCommand : IRequest<Unit> // no content اگر نداشته باشیم یا خالی باشد
    {
        public UpdateLeaveTypeDto LeaveTypeDto { get; set; }

    }
}
