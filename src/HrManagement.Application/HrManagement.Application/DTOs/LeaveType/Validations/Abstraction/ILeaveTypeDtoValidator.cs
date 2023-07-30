using FluentValidation;
using HrManagement.Application.DTOs.LeaveType.DTO.AbstractionDto;

namespace HrManagement.Application.DTOs.LeaveType.Validations.Abstraction
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("{PropertyName} is Required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} Must not exceed 50.");

            RuleFor(p => p.DefaultDay).NotEmpty().WithMessage("{PropertyName} is Required")
                .GreaterThan(0).WithMessage("{PropertyName} Most bigger than 1.")
                .LessThan(100).WithMessage("{PropertyName} Most exceed 100.");
        }
    }
}
