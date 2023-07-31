using AutoMapper;
using HrManagement.Application.DTOs.LeaveType.Validations;
using HrManagement.Application.DTOs.LeaveType.Validations.Abstraction;
using HrManagement.Application.Features.LeaveTypes.Requests.Commands;
using HrManagement.Application.Persistence.Contracts;
using MediatR;
using System;
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
            #region Validation

            var validator = new UpdateLeaveTypeValidation();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new Exception();

            #endregion
            var leaveType = await _leaveTypeRepository.GetById(request.LeaveTypeDto.Id);
            _mapper.Map(request.LeaveTypeDto, leaveType);
            await _leaveTypeRepository.Update(leaveType);

            return Unit.Value; // مقدار خاصی نیست و میتواند همه نوع باشد بسته به موارد خروجی
        }
    }
}
