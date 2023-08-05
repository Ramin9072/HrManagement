using HrManagement.Application.Contracts.Persistence.GenericRepository;
using HrManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<LeaveAllocation> GetLeaveAllocationWithDetailsById(int id);
    }
}
