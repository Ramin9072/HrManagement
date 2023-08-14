using HrManagement.Application.DTOs.LeaveRequest.DTO;
using HrManagement.Application.DTOs.LeaveRequest.DTO.AbstractionDto;
using HrManagement.Application.Features.LeaveRequests.Requests.Command;
using HrManagement.Application.Features.LeaveRequests.Requests.Queries;
using HrManagement.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> GetList()
        {
            var leaveRequests =await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> GetById(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsRequest { Id = id });
            return Ok(leaveRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ILeaveRequestDto createLeaveRequest)
        {
            var command = new CreateLeaveRequestCommand { ILeaveRequestDTO = createLeaveRequest };
            var response = _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequest)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, UpdateLeaveRequestDTO = updateLeaveRequest };
            var response = _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("ChangeLeaveRequestApprove/{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ChangeLeaveRequestApprovedDTO changeLeaveRequestApprovedDTO)
        {
            var command = new UpdateLeaveRequestCommand { Id = id, ChangeLeaveRequestApprovedDTO = changeLeaveRequestApprovedDTO };
            var response = _mediator.Send(command);
            return Ok(response);
        }
    }
}
