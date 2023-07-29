using AutoMapper;
using HrManagement.Application.Features.LeaveAllocations.Requests.Command;
using HrManagement.Application.Persistence.Contracts;
using HrManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveAllocations.Handlers.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocationMapped = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);
            var leaveAllocationOut = await _leaveAllocationRepository.Add(leaveAllocationMapped);
            return leaveAllocationOut.Id;
        }
    }
}
