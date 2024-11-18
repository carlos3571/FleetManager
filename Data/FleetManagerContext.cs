using Microsoft.EntityFrameworkCore;


public class FleetManagerContext : DbContext
{
    public FleetManagerContext(DbContextOptions<FleetManagerContext> options) : base(options) { }

    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<Conductor> Conductores { get; set; }
    public DbSet<Mantenimiento> Mantenimientos { get; set; }
    public DbSet<Asignacion> Asignaciones { get; set; }
    public DbSet<RegistroUso> RegistrosUso { get; set; }
}


