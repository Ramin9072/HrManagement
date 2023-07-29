using AutoMapper;
using HrManagement.Application.DTOs.LeaveAllocation;
using HrManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HrManagement.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class LeaveAllocationDetailsRequestHandler : IRequestHandler<GetLeaveAllocationRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public LeaveAllocationDetailsRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocationDetail =await _leaveAllocationRepository.GetLeaveAllocationWithDetailsById(request.Id);
            return _mapper.Map<LeaveAllocationDto>(leaveAllocationDetail);

        }
    }
}
