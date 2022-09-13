using Microsoft.EntityFrameworkCore;
using MovieTracker.Models.Entities;
using MovieTracker.Models.Entities.Configuration;

namespace MovieTracker.DBContexts
{
    public class MovieTrackerContext : DbContext, IDatabaseContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieType> movieTypes { get; set; }
        public MovieTrackerContext(DbContextOptions<MovieTrackerContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new MovieTypeFillIn());
        }

        public Task SaveAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
