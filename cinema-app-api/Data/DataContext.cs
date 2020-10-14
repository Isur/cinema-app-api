using Microsoft.EntityFrameworkCore;
using cinema_app_api.Models;

namespace cinema_app_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Movies> Movies { get; set; }

    }
}