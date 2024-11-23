using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Asignaciones
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        // Constructor que inyecta el contexto de base de datos
        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }

        // Propiedad para almacenar la lista de asignaciones
        public IList<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();

        public async Task OnGetAsync()
        {
            // Carga todas las asignaciones, incluyendo vehículos y conductores relacionados
            Asignaciones = await _context.Asignaciones
                .Include(a => a.IdVehiculo) // Incluir información del vehículo
                .Include(a => a.IdConductor) // Incluir información del conductor
                .ToListAsync();
        }
    }
}
