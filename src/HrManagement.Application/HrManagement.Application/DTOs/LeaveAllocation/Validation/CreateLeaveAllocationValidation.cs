using FluentValidation;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;
using HrManagement.Application.DTOs.LeaveAllocation.Validation.Abstraction;

namespace HrManagement.Application.DTOs.LeaveAllocation.Validation
{
    public class CreateLeaveAllocationValidation : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationValidation(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            Include(new ILeaveAllocationValidation(_leaveTypeRepository));
        }
    }
}
