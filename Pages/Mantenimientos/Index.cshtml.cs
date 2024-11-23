using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Mantenimientos
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }

        public IList<Mantenimiento> Mantenimientos { get; set; }

        public async Task OnGetAsync()
        {
            Mantenimientos = await _context.Mantenimientos
                .Include(m => m.Vehiculo) // Incluir datos del vehículo relacionado
                .ToListAsync();
        }
    }
}


