using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WatchHereAppMVCProject.Models;

namespace WatchHereAppMVCProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedMovies)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "UserMovie",
                    j => j.HasOne<Movie>().WithMany(),
                    j => j.HasOne<User>().WithMany()
                );
        }

    }
}
