using Microsoft.EntityFrameworkCore;
using MyFitnessWebApp.Models;

namespace MyFitnessWebApp.Data
{
    public class FitnessDbContext : DbContext

    {
        // we need a constructor that accepts our configuration

        public FitnessDbContext(DbContextOptions<FitnessDbContext> options) : base(options) 
        { 

        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gym>().ToTable("Gym");
            modelBuilder.Entity<Workout>().ToTable("Workout");
        }
    }

}
