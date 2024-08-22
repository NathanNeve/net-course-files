using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adventures.Domain.Models;

namespace Adventures.Infrastructure
{
    public class TravelContext : DbContext
    {
        public TravelContext()
        {
        }

        public TravelContext(DbContextOptions<TravelContext> options) : base(options)
        {
        }

        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Traveller>().ToTable("Traveller");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<Booking>().ToTable("Booking");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-Adventures.Web-1ebd4842-7335-4766-bf52-515e617cceb6;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
