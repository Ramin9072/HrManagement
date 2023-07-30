using AutoMapper;
using HrManagement.Application.DTOs.LeaveAllocation.Validation;
using HrManagement.Application.Features.LeaveAllocations.Requests.Command;
using HrManagement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveAllocations.Handlers.Command
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validation = new UpdateLeaveAllocationValidation(_leaveTypeRepository);
            var result = await validation.ValidateAsync(request.LeaveAllocationDto);
            if (result.IsValid == false)
                throw new Exception();

            var allocation = await _leaveAllocationRepository.GetById(request.LeaveAllocationDto.Id);
            _mapper.Map(request.LeaveAllocationDto, allocation);
            await _leaveAllocationRepository.Update(allocation);

            return Unit.Value;
        }
    }
}
