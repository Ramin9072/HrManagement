using HrManagement.Application.Persistence.Contracts.GenericRepository;
using HrManagement.Domain;

namespace HrManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
    }
}
