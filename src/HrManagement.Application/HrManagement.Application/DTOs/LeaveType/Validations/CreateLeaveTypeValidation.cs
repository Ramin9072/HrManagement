using FluentValidation;
using HrManagement.Application.DTOs.LeaveType.DTO;
using HrManagement.Application.DTOs.LeaveType.Validations.Abstraction;

namespace HrManagement.Application.DTOs.LeaveType.Validations
{
    public class CreateLeaveTypeValidation : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeValidation()
        {
            Include(new ILeaveTypeDtoValidator()); // به والد متصل میشود
        }
    }
}
