using Adventures.Domain.Models;
using Adventures.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<Traveller> TravellerRepository { get; }
        Task SaveChanges();

    }
}
