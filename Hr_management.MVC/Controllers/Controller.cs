using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hr_management.MVC.Controllers
{
    public interface IController
    {
        Task<ICollection<LeaveAllocationDto>> LeaveAllocationAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveAllocationPOSTAsync(ILeaveAllocationDto body, CancellationToken cancellationToken = default(CancellationToken));
        Task<LeaveAllocationDto> LeaveAllocationGETAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveAllocationPUTAsync(int id, ILeaveAllocationDto body, CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveAllocationDELETEAsync(string id, DeleteLeaveAllocationDto body, CancellationToken cancellationToken = default(CancellationToken));
        Task<ICollection<LeaveRequestDto>> LeaveRequestAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveRequestPOSTAsync(ILeaveRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
        Task<LeaveRequestDto> LeaveRequestGETAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveRequestPUTAsync(int id, UpdateLeaveRequestDto body, CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveRequestDELETEAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task ChangeLeaveRequestApproveAsync(int id, ChangeLeaveRequestApprovedDTO body, CancellationToken cancellationToken = default(CancellationToken));
        Task<ICollection<LeaveTypeDto>> LeaveTypeAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveTypePOSTAsync(CreateLeaveTypeDto body, CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveTypePUTAsync(UpdateLeaveTypeDto body, CancellationToken cancellationToken = default(CancellationToken));
        Task<LeaveTypeDto> LeaveTypeGETAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task LeaveTypeDELETEAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
    }

    public partial class Controller : ControllerBase
    {
        private IController _implementation;

        public Controller(IController implementation)
        {
            _implementation = implementation;
        }
        [HttpGet, Route("api/LeaveAllocation")]
        public Task<ICollection<LeaveAllocationDto>> LeaveAllocationAll(CancellationToken cancellationToken)
        {

            return _implementation.LeaveAllocationAllAsync(cancellationToken);
        }

        [HttpPost, Route("api/LeaveAllocation")]
        public Task LeaveAllocationPOST([FromBody] ILeaveAllocationDto body, CancellationToken cancellationToken)
        {

            return _implementation.LeaveAllocationPOSTAsync(body, cancellationToken);
        }

        [HttpGet, Route("api/LeaveAllocation/{id}")]
        public Task<LeaveAllocationDto> LeaveAllocationGET([BindRequired] int id, CancellationToken cancellationToken)
        {

            return _implementation.LeaveAllocationGETAsync(id, cancellationToken);
        }

        [HttpPut, Route("api/LeaveAllocation/{id}")]
        public Task LeaveAllocationPUT([BindRequired] int id, [FromBody] ILeaveAllocationDto body, CancellationToken cancellationToken)
        {

            return _implementation.LeaveAllocationPUTAsync(id, body, cancellationToken);
        }

        [HttpDelete, Route("api/LeaveAllocation/{id}")]
        public Task LeaveAllocationDELETE([BindRequired] string id, [FromBody] DeleteLeaveAllocationDto body, CancellationToken cancellationToken)
        {

            return _implementation.LeaveAllocationDELETEAsync(id, body, cancellationToken);
        }
        // leave Request --------------------------------------------------
        [HttpGet, Route("api/LeaveRequest")]
        public Task<ICollection<LeaveRequestDto>> LeaveRequestAll(CancellationToken cancellationToken)
        {

            return _implementation.LeaveRequestAllAsync(cancellationToken);
        }

        [HttpPost, Route("api/LeaveRequest")]
        public Task LeaveRequestPOST([FromBody] ILeaveRequestDto body, CancellationToken cancellationToken)
        {

            return _implementation.LeaveRequestPOSTAsync(body, cancellationToken);
        }

        [HttpGet, Route("api/LeaveRequest/{id}")]
        public Task<LeaveRequestDto> LeaveRequestGET([BindRequired] int id, CancellationToken cancellationToken)
        {

            return _implementation.LeaveRequestGETAsync(id, cancellationToken);
        }

        [HttpPut, Route("api/LeaveRequest/{id}")]
        public Task LeaveRequestPUT([BindRequired] int id, [FromBody] UpdateLeaveRequestDto body, CancellationToken cancellationToken)
        {

            return _implementation.LeaveRequestPUTAsync(id, body, cancellationToken);
        }

        [HttpDelete, Route("api/LeaveRequest/{id}")]
        public Task LeaveRequestDELETE([BindRequired] int id, CancellationToken cancellationToken)
        {

            return _implementation.LeaveRequestDELETEAsync(id, cancellationToken);
        }

        [HttpPut, Route("api/LeaveRequest/ChangeLeaveRequestApprove/{id}")]
        public Task ChangeLeaveRequestApprove([BindRequired] int id, [FromBody] ChangeLeaveRequestApprovedDTO body, CancellationToken cancellationToken)
        {

            return _implementation.ChangeLeaveRequestApproveAsync(id, body, cancellationToken);
        }

        [HttpGet, Route("api/LeaveType/")]
        public Task<ICollection<LeaveTypeDto>> LeaveTypesGET(CancellationToken cancellationToken)
        {

            return _implementation.LeaveTypeAllAsync(cancellationToken);
        }

    }
    public partial class ChangeLeaveRequestApprovedDTO
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("approved", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Approved { get; set; }

    }
    public partial class CreateLeaveTypeDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("defaultDay", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DefaultDay { get; set; }

    }
    public partial class DeleteLeaveAllocationDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

    }
    public partial class ILeaveAllocationDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("numberOfDays", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NumberOfDays { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LeaveTypeDto LeaveType { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveTypeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LeaveTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("period", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Period { get; set; }

    }
    public partial class ILeaveRequestDto
    {
        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime EndDate { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LeaveTypeDto LeaveType { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveTypeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LeaveTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("dateRequested", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime DateRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("requestComment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestComment { get; set; }

        [Newtonsoft.Json.JsonProperty("dateActioned", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime? DateActioned { get; set; }

        [Newtonsoft.Json.JsonProperty("approved", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Approved { get; set; }

        [Newtonsoft.Json.JsonProperty("canceled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Canceled { get; set; }

    }
    public partial class LeaveAllocationDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("numberOfDays", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int NumberOfDays { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LeaveTypeDto LeaveType { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveTypeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LeaveTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("period", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Period { get; set; }

    }
    public partial class LeaveRequestDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime EndDate { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveType", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LeaveTypeDto LeaveType { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveTypeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LeaveTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("dateRequested", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime DateRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("requestComment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestComment { get; set; }

        [Newtonsoft.Json.JsonProperty("dateActioned", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime? DateActioned { get; set; }

        [Newtonsoft.Json.JsonProperty("approved", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Approved { get; set; }

        [Newtonsoft.Json.JsonProperty("canceled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Canceled { get; set; }

    }
    public partial class LeaveTypeDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("defaultDay", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DefaultDay { get; set; }

    }
    public partial class UpdateLeaveRequestDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime StartDate { get; set; }

        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateTime EndDate { get; set; }

        [Newtonsoft.Json.JsonProperty("leaveTypeId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LeaveTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("requestComment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestComment { get; set; }

        [Newtonsoft.Json.JsonProperty("canceled", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Canceled { get; set; }

    }
    public partial class UpdateLeaveTypeDto
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("defaultDay", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DefaultDay { get; set; }

    }
}

