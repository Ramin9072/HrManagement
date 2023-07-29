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
           
        }
    }
}
