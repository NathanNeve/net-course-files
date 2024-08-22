using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task SaveChangesAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter = null);
        Task<T> DeleteAsync(int id);
    }
}
