using Microsoft.EntityFrameworkCore;
using VSA.Api.Entities;
using System.Reflection;

namespace VSA.Api.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
