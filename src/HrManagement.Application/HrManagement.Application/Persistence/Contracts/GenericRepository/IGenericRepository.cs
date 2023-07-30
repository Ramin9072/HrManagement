
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HrManagement.Application.Persistence.Contracts.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exist(int id);
        Task<T> Add(T entory);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
    }
}
