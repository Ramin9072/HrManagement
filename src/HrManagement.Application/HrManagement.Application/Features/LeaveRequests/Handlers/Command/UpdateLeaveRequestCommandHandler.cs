using AutoMapper;
using HrManagement.Application.Features.LeaveRequests.Requests.Command;
using HrManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveRequests.Handlers.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetById(request.Id);

            if (request.UpdateLeaveRequestDTO != null)
            {
                _mapper.Map(request.UpdateLeaveRequestDTO, leaveRequest);
                await _leaveRequestRepository.Update(leaveRequest);
            }
            else if (request.ChangeLeaveRequestApprovedDTO != null)
            {
                await _leaveRequestRepository
                    .ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovedDTO.Approved);
            }
            return Unit.Value;
        }
    }
}
