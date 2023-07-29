using HrManagement.Application.Persistence.Contracts.GenericRepository;
using HrManagement.Domain;
using System.Threading.Tasks;

namespace HrManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetailsById(int id);
        Task<LeaveRequest> GetLeaveRequestsWithDetails();
        Task<LeaveRequest> ChangeApprovalStatus(LeaveRequest leaveRequest, bool? changeApprovalStatus);
    }
}
