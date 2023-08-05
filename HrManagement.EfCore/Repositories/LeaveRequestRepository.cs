using HrManagement.Application.Contracts.Persistence;
using HrManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.EfCore.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LeaveRequest> ChangeApprovalStatus(LeaveRequest leaveRequest, bool? changeApprovalStatus)
        {
            var leaveRequestChanged = new LeaveRequest.Builder().Approved(changeApprovalStatus).Create();
            _dbContext.Entry(leaveRequestChanged).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return leaveRequestChanged;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var details = await _dbContext.LeaveRequests
                .Include(p => p.LeaveType)
                .ToListAsync();
            return details;

        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetailsById(int id)
        {
            var leaveRequestDetail = await _dbContext.LeaveRequests
                .Include(p => p.LeaveType)
                .FirstOrDefaultAsync(p => p.Id == id);

            return leaveRequestDetail;
        }
    }
}
