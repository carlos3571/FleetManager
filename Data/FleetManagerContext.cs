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

        public DbSet<Vehiculo> Vehiculos { get; set; }
    }
}



