using Adventures.Domain.Models;
using Adventures.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private TravelContext _context;
        private IRepository<Traveller> _travellerRepository;

        public UnitOfWork(TravelContext context)
        {
            _context = context;
        }

        public IRepository<Traveller> TravellerRepository
        {
            get
            {
                if (_travellerRepository == null)
                {
                    _travellerRepository = new TravellerRepository(_context);
                }
                return _travellerRepository;
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
