using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data; // Cambia según el espacio de nombres
using FleetManager.Models; // Cambia según el espacio de nombres

namespace FleetManager.Pages.Vehiculos // Asegúrate que coincida con tu estructura
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        // Constructor que inyecta el contexto
        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }

        // Propiedad que contiene la lista de vehículos
        public IList<Vehiculos> Vehiculos { get; set; } = new List<Vehiculo>();

        // Método que se ejecuta al cargar la página
        public async Task OnGetAsync()
        {
            Vehiculos = await _context.Vehiculos.ToListAsync();
        }
    }
}

