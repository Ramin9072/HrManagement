using HrManagement.Application.Persistence.Contracts.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.EfCore.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly LeaveManagementDbContext _context;

        public GenericRepository(LeaveManagementDbContext context)
        {
            _context = context;
        }

        #region GET

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<bool> Exist(int id)
        {
            var entity = await GetById(id);
            return entity != null;
        }

        #endregion

        #region IUD

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;

        }
        public async Task<T> Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
