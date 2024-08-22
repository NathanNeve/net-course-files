using Adventures.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Infrastructure.Repositories
{
    public class TravellerRepository : GenericRepository<Traveller>
    {
        private readonly TravelContext _context;

        public TravellerRepository(TravelContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Traveller>> ReadAllAsync()
        {
            var travellers = _context.Travellers.Include(t => t.Bookings);
            return await travellers.ToListAsync();
        }
    }
}
