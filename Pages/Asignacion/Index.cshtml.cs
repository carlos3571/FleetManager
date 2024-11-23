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
            // Carga todas las asignaciones, incluyendo veh�culos y conductores relacionados
            Asignaciones = await _context.Asignaciones
                .Include(a => a.IdVehiculo) // Incluir informaci�n del veh�culo
                .Include(a => a.IdConductor) // Incluir informaci�n del conductor
                .ToListAsync();
        }
    }
}
