using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.Exceptions;
using HrManagement.Application.Features.LeaveAllocations.Requests.Command;
using HrManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveAllocations.Handlers.Command
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var allocation = await _leaveAllocationRepository.GetById(request.DeleteLeaveAllocationDto.Id);

            if (allocation == null)
                throw new NotFoundException(nameof(LeaveAllocation), request.DeleteLeaveAllocationDto.Id);

            await _leaveAllocationRepository.Delete(allocation);
        }
    }
}
