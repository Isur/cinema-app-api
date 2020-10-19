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
    }
}