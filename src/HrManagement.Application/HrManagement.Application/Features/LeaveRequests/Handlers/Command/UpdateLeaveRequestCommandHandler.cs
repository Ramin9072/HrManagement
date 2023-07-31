using AutoMapper;
using HrManagement.Application.DTOs.LeaveRequest.Validation;
using HrManagement.Application.Features.LeaveRequests.Requests.Command;
using HrManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveRequests.Handlers.Command
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validation = new UpdateLeaveRequestValidator(_leaveTypeRepository);
            var result = await validation.ValidateAsync(request.ILeaveRequestDTO);
            if (result.IsValid == false)
                throw new Exception();

            #endregion

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
