using HrManagement.Application.Contracts.Persistence;
using HrManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.EfCore.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _context;

        public LeaveAllocationRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocationList = await _context.LeaveAllocations
                .Include(p=>p.LeaveType)
                .ToListAsync();
            return leaveAllocationList;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetailsById(int id)
        {
            var leaveAllocation = await _context.LeaveAllocations
                .Include(p => p.LeaveType)
                .FirstOrDefaultAsync(p=>p.Id == id);
            return leaveAllocation;
            
        }
    }
}
