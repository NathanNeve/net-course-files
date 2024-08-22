using MotoGP.Models;
using Microsoft.EntityFrameworkCore;

namespace MotoGP.Data
{
    public class GPContext : DbContext
    {
        public GPContext(DbContextOptions<GPContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("Countries");
            modelBuilder.Entity<Race>().ToTable("Races");
            modelBuilder.Entity<Rider>().ToTable("Riders");
            modelBuilder.Entity<Team>().ToTable("Teams");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");

        }
    }
}