using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManager.Pages.VehiculosView
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public IndexModel(FleetManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Cambiar el tipo de lista a Vehiculo
        public IList<Vehiculo> Vehiculos { get; set; }

        public async Task OnGetAsync()
        {
            // Obtener la lista de vehículos correctamente
            Vehiculos = await _context.Vehiculos.ToListAsync();
        }
    }
}

