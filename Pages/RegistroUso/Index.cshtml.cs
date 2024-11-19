using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.RegistrosUso
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }

        public IList<RegistroUso> RegistrosUso { get; set; }

        public async Task OnGetAsync()
        {
            RegistrosUso = await _context.RegistrosUso
                .Include(r => r.Vehiculo) // Incluye la relación con Vehículo
                .ToListAsync();
        }
    }
}
