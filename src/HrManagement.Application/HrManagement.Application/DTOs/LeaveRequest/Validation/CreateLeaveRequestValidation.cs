using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HrManagement.Application.DTOs.LeaveRequest.Validation
{
    public class CreateLeaveRequestValidation : AbstractValidator<CreateLeaveRequestDTO>
    {
        public CreateLeaveRequestValidation()
        {
            RuleFor(p => p.StartDate).NotEmpty().WithMessage("{PropertyName} cannot be empty ")
                 .GreaterThan(p => p.EndDate).WithMessage("{PropertyName} Must smaller than EndDate");
                
            RuleFor(p=>p.EndDate).NotEmpty().WithMessage("{PropertyName} cannot be empty ")
                .LessThan(p=>p.StartDate).WithMessage("{PropertyName} Must smaller than StartDate");

            RuleFor(p => p.LeaveTypeId).NotNull();

            RuleFor(p => p.EndDate).NotEmpty().WithMessage("{PropertyName} cannot be empty ")
               .GreaterThan(p => DateTime.Now).WithMessage("{PropertyName} Must smaller than Now");

            RuleFor(p => p.RequestComment).MinimumLength(250).WithMessage("{PropertyName} Less than 250")
                .MinimumLength(0).WithMessage("{PropertyName} More than 1 ");
        }
    }
}
