using FleetManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Data
{
    public class FleetManagerContext : DbContext
    {
        public FleetManagerContext(DbContextOptions<FleetManagerContext> options)
            : base(options)
        {
        }

        // DbSet para las entidades
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<RegistroUso> RegistroUsos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para la entidad Conductor
            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.HasKey(c => c.IdConductor);

                entity.Property(c => c.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(c => c.LicenciaConduccion)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(c => c.Telefono)
                    .HasMaxLength(15);

                entity.Property(c => c.Direccion)
                    .HasMaxLength(100);

                entity.HasMany(c => c.Asignaciones)
                    .WithOne(a => a.Conductor)
                    .HasForeignKey(a => a.IdConductor)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración para la entidad Asignacion
            modelBuilder.Entity<Asignacion>(entity =>
            {
                entity.HasKey(a => a.IdAsignacion);

                // Relación con Vehiculo
                entity.HasOne(a => a.Vehiculo)
                    .WithMany(v => v.Asignaciones)
                    .HasForeignKey(a => a.IdVehiculo)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relación con Conductor
                entity.HasOne(a => a.Conductor)
                    .WithMany(c => c.Asignaciones)
                    .HasForeignKey(a => a.IdConductor)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración para la entidad Vehiculo
            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(v => v.IdVehiculo);

                entity.Property(v => v.Placa)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(v => v.Marca)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(v => v.Modelo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(v => v.Año)
                    .IsRequired();

                entity.Property(v => v.Kilometraje)
                    .IsRequired();

                entity.HasMany(v => v.Asignaciones)
                    .WithOne(a => a.Vehiculo)
                    .HasForeignKey(a => a.IdVehiculo)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración para la entidad Mantenimiento
            modelBuilder.Entity<Mantenimiento>(entity =>
            {
                entity.HasKey(m => m.IdMantenimiento);

                entity.HasOne(m => m.Vehiculo)
                    .WithMany()
                    .HasForeignKey(m => m.IdVehiculo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(m => m.Descripcion)
                    .IsRequired();

                entity.Property(m => m.FechaMantenimiento)
                    .IsRequired();

                entity.Property(m => m.Costo)
                    .IsRequired()
                    .HasColumnType("decimal(10, 2)");
            });

            // Configuración para la entidad RegistroUso
            modelBuilder.Entity<RegistroUso>(entity =>
            {
                entity.HasKey(r => r.IdRegistro);

                entity.HasOne(r => r.Vehiculo)
                    .WithMany()
                    .HasForeignKey(r => r.IdVehiculo)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(r => r.Fecha)
                    .IsRequired();

                entity.Property(r => r.KilometrajeInicio)
                    .IsRequired();

                entity.Property(r => r.KilometrajeFin)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
