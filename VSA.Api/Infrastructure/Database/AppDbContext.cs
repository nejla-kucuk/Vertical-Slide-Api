using Microsoft.EntityFrameworkCore;
using VSA.Api.Entities;
using Microsoft.Extensions.Configuration;
using System;


namespace VSA.Api.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Instruments> Instruments { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Brand>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Brand>()
                .Property(b => b.DisplayText)
                .IsRequired();

            modelBuilder.Entity<Brand>()
                .Property(b => b.Address)
                .IsRequired(); 

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Instruments) 
                .WithOne(i => i.Brand) 
                .HasForeignKey(i => i.BrandId); 


            modelBuilder.Entity<Instruments>()
                .HasKey(i => i.Id); 

            modelBuilder.Entity<Instruments>()
                .Property(i => i.Model)
                .IsRequired(); 

            modelBuilder.Entity<Instruments>()
                .Property(i => i.Color)
                .IsRequired(); 

            modelBuilder.Entity<Instruments>()
                .Property(i => i.ProductionYear)
                .HasColumnType("date"); 

            modelBuilder.Entity<Instruments>()
                .Property(i => i.Price)
                .HasColumnType("decimal(18,2)") 
                .IsRequired(); 

            modelBuilder.Entity<Instruments>()
                .HasOne(i => i.Brand) 
                .WithMany(b => b.Instruments) 
                .HasForeignKey(i => i.BrandId)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }



    }
}
