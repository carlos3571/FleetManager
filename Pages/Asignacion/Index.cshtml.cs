using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data; // Cambia seg�n el espacio de nombres
using FleetManager.Models; // Cambia seg�n el espacio de nombres

namespace FleetManager.Pages.Vehiculos // Aseg�rate que coincida con tu estructura
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        // Constructor que inyecta el contexto
        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }

        // Propiedad que contiene la lista de veh�culos
        public IList<Vehiculos> Vehiculos { get; set; } = new List<Vehiculo>();

        // M�todo que se ejecuta al cargar la p�gina
        public async Task OnGetAsync()
        {
            Vehiculos = await _context.Vehiculos.ToListAsync();
        }
    }
}

