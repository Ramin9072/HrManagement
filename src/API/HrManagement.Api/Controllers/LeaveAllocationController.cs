using HrManagement.Application.DTOs.LeaveAllocation.DTO;
using HrManagement.Application.DTOs.LeaveAllocation.DTO.AbstractionDto;
using HrManagement.Application.Features.LeaveAllocations.Requests.Command;
using HrManagement.Application.Features.LeaveAllocations.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace HrManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> GetList()
        {
            var leaveAllocations = new GetLeaveAllocationListRequest();
            await _mediator.Send(leaveAllocations);
            return Ok(leaveAllocations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationRequest { Id = id });
            return Ok(leaveAllocation);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ILeaveAllocationDto createLeaveAllocationDto)
        {
            var request = new CreateLeaveAllocationCommand { ILeaveAllocationDto = createLeaveAllocationDto };
            var response = _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ILeaveAllocationDto updateLeaveAllocationDto)
        {
            var request = new UpdateLeaveAllocationCommand { LeaveAllocationDto = updateLeaveAllocationDto };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] DeleteLeaveAllocationDto deleteLeaveAllocationDto)
        {
            var request = new DeleteLeaveAllocationCommand { DeleteLeaveAllocationDto = deleteLeaveAllocationDto };
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
