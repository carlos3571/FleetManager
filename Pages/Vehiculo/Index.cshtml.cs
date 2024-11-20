using FleetManager.Data;
using FleetManager.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Pages.Vehiculos
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }

        public IList<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

        public async Task OnGetAsync()
        {
            Vehiculos = await _context.Vehiculos.ToListAsync();
        }
    }
}
