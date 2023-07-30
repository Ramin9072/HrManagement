using FluentValidation;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using HrManagement.Application.DTOs.LeaveRequest.Validation.Abstraction;
using HrManagement.Application.Persistence.Contracts;

namespace HrManagement.Application.DTOs.LeaveRequest.Validation
{
    public class UpdateLeaveRequestValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveRequestValidator(_leaveTypeRepository));
        }
    }
}
