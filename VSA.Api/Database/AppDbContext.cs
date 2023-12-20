using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using VSA.Api.Entities;

namespace VSA.Api.Database
{
    public class AppDbContext : DbContext
    {
        DbSet<Instrument> Instruments { get; set; }

        DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instrument>(builder =>
                            builder.OwnsOne(a => a.Id, tagsBuilder => tagsBuilder.ToJson()));

            modelBuilder.Entity<Brand>(builder =>
                            builder.OwnsOne(a => a.Id, tagsBuilder => tagsBuilder.ToJson()));
        }
    }
}
