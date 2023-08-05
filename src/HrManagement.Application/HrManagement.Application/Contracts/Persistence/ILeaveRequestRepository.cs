using HrManagement.Application.Contracts.Persistence.GenericRepository;
using HrManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetailsById(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> ChangeApprovalStatus(LeaveRequest leaveRequest, bool? changeApprovalStatus);
    }
}
