using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveType.Validations;
using HrManagement.Application.Features.LeaveTypes.Requests.Commands;
using HrManagement.Application.Responses;
using HrManagement.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            #region Validation
            var response = new BaseCommandResponse.Builder();

            var validator = new CreateLeaveTypeValidation();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
            {
                return response
                    .Success(false)
                    .Message("Creation failed")
                    .Errors(validationResult.Errors.Select(p => p.ErrorCode).ToList())
                    .Create();
                //throw new ValidationException(validationResult);
            }
            #endregion

            var leaveTypeMap = _mapper.Map<LeaveType>(request.LeaveTypeDto);
            var leavetypeSaved = await _leaveTypeRepository.Add(leaveTypeMap);

            var result = response
                .Success(true)
                .Message("Creation successFull")
                .Id(leaveTypeMap.Id).Create();

            return result;
        }
    }
}
