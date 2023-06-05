using e_Tickets.Models;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ):base(options)
        {
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ActorMovie>()
        //        .HasKey(am => new { am.MovieId, am.ActorId });
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.MovieId, am.ActorId });

            modelBuilder.Entity<ActorMovie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<ActorMovie>().HasOne(m => m.Movie).WithMany(am => am.ActorsMovies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<ActorMovie>().HasOne(m => m.Actor).WithMany(am => am.ActorsMovies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);
        }

        internal Task AddASync(Actor actor)
        {
            throw new NotImplementedException();
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorsMovies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<User> Users { get; set; }


        //Order related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
