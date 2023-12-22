using Microsoft.EntityFrameworkCore;
using VSA.Api.Entities;
using Microsoft.Extensions.Configuration;
using System;


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
            modelBuilder.Entity<Brand>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Brand>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<Brand>()
                .Property(b => b.DisplayText)
                .IsRequired(); // DisplayText alanının zorunlu olduğunu belirtiyoruz.

            modelBuilder.Entity<Brand>()
                .Property(b => b.Address)
                .IsRequired(); // Address alanının zorunlu olduğunu belirtiyoruz.

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Instruments) // Brand sınıfının Instruments navigation property'si için ilişkiyi belirtiyoruz.
                .WithOne(i => i.Brand) // Instrument sınıfının Brand navigation property'si ile ilişkiyi belirtiyoruz.
                .HasForeignKey(i => i.Id); // Instrument sınıfının BrandId foreign key'ini belirtiyoruz.


            modelBuilder.Entity<Instrument>()
                .HasKey(i => i.Id); // Instrument sınıfının anahtar alanını belirtiyoruz.

            modelBuilder.Entity<Instrument>()
                .Property(i => i.Model)
                .IsRequired(); // Model alanının zorunlu olduğunu belirtiyoruz.

            modelBuilder.Entity<Instrument>()
                .Property(i => i.Color)
                .IsRequired(); // Color alanının zorunlu olduğunu belirtiyoruz.

            modelBuilder.Entity<Instrument>()
                .Property(i => i.ProductionYear)
                .HasColumnType("date"); // ProductionYear alanının tipini belirtiyoruz, örneğin date tipi.

            modelBuilder.Entity<Instrument>()
                .Property(i => i.Price)
                .HasColumnType("decimal(18,2)") // Price alanının tipini ve precision/scale değerlerini belirtiyoruz.
                .IsRequired(); // Price alanının zorunlu olduğunu belirtiyoruz.

            modelBuilder.Entity<Instrument>()
                .HasOne(i => i.Brand) // Instrument sınıfının Brand navigation property'si ile ilişkiyi belirtiyoruz.
                .WithMany(b => b.Instruments) // Brand sınıfının Instruments navigation property'si ile ilişkiyi belirtiyoruz.
                .HasForeignKey(i => i.Id) // Instrument sınıfının BrandId foreign key'ini belirtiyoruz.
                .OnDelete(DeleteBehavior.Cascade); // Eğer bir Brand silinirse, bağlı Instrument'ları da siler.

            base.OnModelCreating(modelBuilder);
        }



    }
}
