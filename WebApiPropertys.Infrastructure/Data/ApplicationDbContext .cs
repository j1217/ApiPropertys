using Microsoft.EntityFrameworkCore;
using WebApiPropertys.Domain.Models;

namespace WebApiPropertys.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets para las entidades
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }

        // Configuración de relaciones y validaciones con Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la entidad Owner
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(o => o.IdOwner); // Clave primaria
                entity.Property(o => o.Name).IsRequired().HasMaxLength(255);
                entity.Property(o => o.Address).IsRequired().HasMaxLength(500);
                entity.Property(o => o.Photo).IsRequired();
                entity.Property(o => o.Birthday).IsRequired();
            });

            // Configuración para la entidad Property
            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(p => p.IdProperty); // Clave primaria
                entity.Property(p => p.Name).IsRequired().HasMaxLength(255);
                entity.Property(p => p.Address).HasMaxLength(500);
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(p => p.CodeInternal).HasMaxLength(50);
                entity.Property(p => p.Year).IsRequired(false);

                // Relación con Owner (FK)
                entity.HasOne(p => p.Owner)
                      .WithMany(o => o.Properties)
                      .HasForeignKey(p => p.IdOwner)
                      .OnDelete(DeleteBehavior.SetNull); // Configuración de eliminación en cascada
            });

            // Configuración para la entidad PropertyImage
            modelBuilder.Entity<PropertyImage>(entity =>
            {
                entity.HasKey(pi => pi.IdPropertyImage); // Clave primaria
                entity.Property(pi => pi.FileProperty).IsRequired();
                entity.Property(pi => pi.Enable).IsRequired(false);

                // Relación con Property (FK)
                entity.HasOne(pi => pi.Property)
                      .WithMany(p => p.PropertyImages)
                      .HasForeignKey(pi => pi.IdProperty)
                      .OnDelete(DeleteBehavior.SetNull); // Configuración de eliminación en cascada
            });

            // Configuración para la entidad PropertyTrace
            modelBuilder.Entity<PropertyTrace>(entity =>
            {
                entity.HasKey(pt => pt.IdPropertyTrace); // Clave primaria
                entity.Property(pt => pt.Name).HasMaxLength(255);
                entity.Property(pt => pt.Value).HasColumnType("decimal(18,2)");
                entity.Property(pt => pt.Tax).HasColumnType("decimal(18,2)");
                entity.Property(pt => pt.DataSale).HasColumnType("datetime");

                // Relación con Property (FK)
                entity.HasOne(pt => pt.Property)
                      .WithMany(p => p.PropertyTraces)
                      .HasForeignKey(pt => pt.IdProperty)
                      .OnDelete(DeleteBehavior.SetNull); // Configuración de eliminación en cascada
            });
        }
    }
}
