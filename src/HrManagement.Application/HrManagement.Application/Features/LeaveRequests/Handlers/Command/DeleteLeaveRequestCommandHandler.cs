using HrManagement.Application.Exceptions;
using HrManagement.Application.Features.LeaveRequests.Requests.Command;
using HrManagement.Application.Persistence.Contracts;
using HrManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveRequests.Handlers.Command
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {

        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public async Task Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetById(request.Id);

            if (leaveRequest == null)
                throw new NotFoundException(nameof(LeaveRequest),request.Id);
            
            await _leaveRequestRepository.Delete(leaveRequest);
        }
    }
}
