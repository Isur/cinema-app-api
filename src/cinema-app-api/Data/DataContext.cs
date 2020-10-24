using Microsoft.EntityFrameworkCore;
using cinema_app_api.Models;

namespace cinema_app_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Halls> Halls { get; set; }
        public DbSet<Showings> Showings { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Halls>(entity => {
                entity.HasMany(p => p.Showings).WithOne(d => d.Hall).HasForeignKey(d => d.HallId);
            });
            builder.Entity<Movies>(entity => {
                entity.HasMany(p => p.Showings).WithOne(d => d.Movie).HasForeignKey(d => d.MovieId);
            });
            builder.Entity<Showings>(entity => {
                entity.HasMany(p => p.Tickets).WithOne(d => d.Showing).HasForeignKey(d => d.ShowingId);
            });
            builder.Entity<Users>(entity => {
                entity.HasMany(p => p.Tickets).WithOne(d => d.User).HasForeignKey(d => d.UserId);
            });
        }
    }
}