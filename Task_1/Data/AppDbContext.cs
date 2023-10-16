using Microsoft.EntityFrameworkCore;
using Task_1.Models;

namespace Task_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
