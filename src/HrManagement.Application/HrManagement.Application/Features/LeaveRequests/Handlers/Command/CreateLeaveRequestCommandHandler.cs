using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveRequest.Validation;
using HrManagement.Application.Exceptions;
using HrManagement.Application.Features.LeaveRequests.Requests.Command;
using HrManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveRequests.Handlers.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validation = new CreateLeaveRequestValidator(_leaveTypeRepository);
            var validationResult = await validation.ValidateAsync(request.ILeaveRequestDTO);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            #endregion

            var leaveRequestMaped = _mapper.Map<LeaveRequest>(request.ILeaveRequestDTO);
            var leaveRequestout = await _leaveRequestRepository.Add(leaveRequestMaped);
            return leaveRequestMaped.Id;
        }
    }
}
