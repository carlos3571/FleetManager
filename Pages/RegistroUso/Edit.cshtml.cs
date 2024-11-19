using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.RegistrosUso
{
    public class EditModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public EditModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegistroUso RegistroUso { get; set; }

        public SelectList Vehiculos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RegistroUso = await _context.RegistrosUso
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(r => r.IdRegistro == id);

            if (RegistroUso == null)
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

            var registroExistente = await _context.RegistrosUso.FindAsync(RegistroUso.IdRegistro);

            if (registroExistente == null)
            {
                return NotFound();
            }

            // Actualizar los campos del registro de uso
            registroExistente.IdVehiculo = RegistroUso.IdVehiculo;
            registroExistente.Fecha = RegistroUso.Fecha;
            registroExistente.KilometrajeInicio = RegistroUso.KilometrajeInicio;
            registroExistente.KilometrajeFin = RegistroUso.KilometrajeFin;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

