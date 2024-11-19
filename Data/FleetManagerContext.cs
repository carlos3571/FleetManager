using Microsoft.EntityFrameworkCore;
using FleetManager.Models;

namespace FleetManager.Data
{
    public class FleetManagerContext : DbContext
    {
        public FleetManagerContext(DbContextOptions<FleetManagerContext> options)
            : base(options)
        {
        }

        // DbSets para las entidades
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<RegistroUso> RegistrosUso { get; set; }

        // Configuraciones adicionales
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para Vehiculo
            modelBuilder.Entity<Vehiculo>()
                .HasKey(v => v.IdVehiculo);

            // Configuración para Conductor
            modelBuilder.Entity<Conductor>()
                .HasKey(c => c.IdConductor);

            // Configuración para Asignacion
            modelBuilder.Entity<Asignacion>()
                .HasKey(a => a.IdAsignacion);
            modelBuilder.Entity<Asignacion>()
                .HasOne(a => a.Vehiculo)
                .WithMany() // Opcional: especifica si deseas relación de muchos a uno o uno a uno
                .HasForeignKey(a => a.IdVehiculo)
                .OnDelete(DeleteBehavior.Cascade);
                 // Configuración para Mantenimiento
            modelBuilder.Entity<Mantenimiento>()
                .HasKey(m => m.IdMantenimiento);
            modelBuilder.Entity<Mantenimiento>()
                .HasOne(m => m.Vehiculo)
                .WithMany() // Relación opcional
                .HasForeignKey(m => m.IdVehiculo)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración para RegistroUso
            modelBuilder.Entity<RegistroUso>()
                .HasKey(r => r.IdRegistro);
            modelBuilder.Entity<RegistroUso>()
                .HasOne(r => r.Vehiculo)
                .WithMany() // Relación opcional
                .HasForeignKey(r => r.IdVehiculo)
                .OnDelete(DeleteBehavior.Cascade);

                // modelBuilder.Entity<Asignacion>()
               //  .HasOne(a => a.Conductor)
               //.WithMany(static c => c.Asignaciones)
               //.HasForeignKey(a => a.IdConductor)
              // .OnDelete(DeleteBehavior.Cascade);
        }
    }
}




