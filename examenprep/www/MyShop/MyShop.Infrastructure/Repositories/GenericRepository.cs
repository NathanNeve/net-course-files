using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private ShoppingContext _shoppingContext;
        private DbSet<T> table = null;

        public GenericRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
            table = _shoppingContext.Set<T>();
        }

        public virtual async Task<T> AddAsync(T obj)
        {
            await table.AddAsync(obj);
            return obj;
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await table.ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T obj)
        {
            table.Update(obj);
            return obj;
        }

        public async Task SaveChangesAsync()
        {
            await _shoppingContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = table;

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }

        public async Task<T> DeleteAsync(int id)
        {
            var obj = await table.FindAsync(id);
            if (obj != null)
            {
                table.Remove(obj);
            }
            return obj;
        }
    }
}
