using HrManagement.Application.Persistence.Contracts.GenericRepository;
using HrManagement.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();
        Task<LeaveAllocation> GetLeaveAllocationWithDetailsById(int id);
    }
}
