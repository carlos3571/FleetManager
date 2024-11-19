using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Mantenimientos
{
    public class EditModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public EditModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mantenimiento Mantenimiento { get; set; }

        public SelectList Vehiculos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mantenimiento = await _context.Mantenimientos
                .Include(m => m.Vehiculo)
                .FirstOrDefaultAsync(m => m.IdMantenimiento == id);

            if (Mantenimiento == null)
            {
                return NotFound();
            }

            Vehiculos = new SelectList(await _context.Vehiculos.ToListAsync(), "IdVehiculo", "Placa");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Vehiculos = new SelectList(await _context.Vehiculos.ToListAsync(), "IdVehiculo", "Placa");
                return Page();
            }

            var mantenimientoExistente = await _context.Mantenimientos.FindAsync(Mantenimiento.IdMantenimiento);

            if (mantenimientoExistente == null)
            {
                return NotFound();
            }

            // Actualizar los campos del mantenimiento
            mantenimientoExistente.IdVehiculo = Mantenimiento.IdVehiculo;
            mantenimientoExistente.FechaMantenimiento = Mantenimiento.FechaMantenimiento;
            mantenimientoExistente.Descripcion = Mantenimiento.Descripcion;
            mantenimientoExistente.Costo = Mantenimiento.Costo;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

