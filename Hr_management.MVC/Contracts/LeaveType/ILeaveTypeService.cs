using Hr_management.MVC.Models.LeaveType;
using Hr_management.MVC.Services.Base;

namespace Hr_management.MVC.Contracts.LeaveType
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetailById(int id);
        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType);
        Task<Response<int>> UpdateLeaveType(LeaveTypeVM leaveType);
        Task DeleteLeaveType(LeaveTypeVM leaveType);
    }
}
