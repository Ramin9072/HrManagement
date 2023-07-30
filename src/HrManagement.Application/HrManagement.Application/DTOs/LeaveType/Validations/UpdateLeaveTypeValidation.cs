using FluentValidation;
using HrManagement.Application.DTOs.LeaveType.DTO;
using HrManagement.Application.DTOs.LeaveType.Validations.Abstraction;

namespace HrManagement.Application.DTOs.LeaveType.Validations
{
    public class UpdateLeaveTypeValidation : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeValidation()
        {
            Include(new ILeaveTypeDtoValidator());
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is Required.");
        }
    }
}
