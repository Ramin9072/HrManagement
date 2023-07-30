using FluentValidation;
using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;
using HrManagement.Application.Persistence.Contracts;

namespace HrManagement.Application.DTOs.LeaveAllocation.Validation.Abstraction
{
    public class ILeaveAllocationValidation : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationValidation(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            RuleFor(p => p.NumberOfDays).NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must greater than 1 day")
                .LessThan(3).WithMessage("{PropertyName} less than 4 day");

            RuleFor(p => p.LeaveTypeId).NotNull().MustAsync(async (id, token) =>
            {
                var isExustLeaveType = await _leaveTypeRepository.Exist(id);
                return !isExustLeaveType;
            });
        }

    }
}
