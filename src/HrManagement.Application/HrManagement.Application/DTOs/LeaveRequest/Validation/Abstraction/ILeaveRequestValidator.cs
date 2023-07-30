using FluentValidation;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using HrManagement.Application.Persistence.Contracts;
using System;

namespace HrManagement.Application.DTOs.LeaveRequest.Validation.Abstraction
{
    public class ILeaveRequestValidator : AbstractValidator<ILeaveRequestDto>
    {
        public readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate).NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                 .LessThan(p => p.EndDate).WithMessage("{PropertyName} must be before {CompresionValue}"); //CompresionValue Second Validator property

            RuleFor(p => p.EndDate).NotEmpty().WithMessage("{PropertyName} cannot be empty.")
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {CompresionValue}");

            RuleFor(p => p.EndDate).NotEmpty().WithMessage("{PropertyName} cannot be empty.")
               .GreaterThan(p => DateTime.Now).WithMessage("{PropertyName} Must smaller than Now.");

            RuleFor(p => p.RequestComment).MinimumLength(250).WithMessage("{PropertyName} Less than 250.")
                .MinimumLength(0).WithMessage("{PropertyName} More than 1.");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0).WithMessage("{PropertyName} does not exist")
                .NotNull()
                .MustAsync(async (id, token) => // make sure we have id for LeaveType for this entity
                {
                    var leaveTypeExist = await _leaveTypeRepository.Exist(id);
                    return !leaveTypeExist;
                });
        }
    }
}
