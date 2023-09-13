using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveType.Validations;
using HrManagement.Application.Exceptions;
using HrManagement.Application.Features.LeaveTypes.Requests.Commands;
using HrManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {


                #region Validation

                var validator = new UpdateLeaveTypeValidation();
                var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);

                #endregion
                //var oldLeaveType = await _leaveTypeRepository.GetById(request.LeaveTypeDto.Id);
                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);
                await _leaveTypeRepository.Update(leaveType);

                return Unit.Value; // مقدار خاصی نیست و میتواند همه نوع باشد بسته به موارد خروجی
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
