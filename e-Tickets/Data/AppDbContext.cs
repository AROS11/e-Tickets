using e_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
        {
            
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorsMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
