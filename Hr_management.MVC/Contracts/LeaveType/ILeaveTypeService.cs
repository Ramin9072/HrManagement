using Hr_management.MVC.Models;
using Hr_management.MVC.Services.Base;

namespace Hr_management.MVC.Contracts.LeaveType
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVM>> GetLeaveTypes();
        Task<LeaveTypeVM> GetLeaveTypeDetailById(int id);
        Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType);
        Task UpdateLeaveType(LeaveTypeVM leaveType);
        Task DeleteLeaveType(LeaveTypeVM leaveType);
    }
}
