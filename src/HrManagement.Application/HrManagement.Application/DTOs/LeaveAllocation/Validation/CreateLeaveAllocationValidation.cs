using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrManagement.Application.DTOs.LeaveAllocation.Validation
{
    public  class CreateLeaveAllocationValidation : AbstractValidator<CreateLeaveAllocationDto>
    {
        public CreateLeaveAllocationValidation()
        {
            RuleFor(p => p.NumberOfDays).NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 1 day")
                .LessThan(3).WithMessage("{PropertyName} less than 4 day");
        }
    }
}
