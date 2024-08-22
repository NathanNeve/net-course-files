using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        private TravelContext _context;
        private DbSet<T> table = null;

        public GenericRepository(TravelContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await table.ToListAsync();
        }
    }
}
