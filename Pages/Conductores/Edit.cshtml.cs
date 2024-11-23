using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;
using System.Threading.Tasks;

namespace FleetManager.Pages.Conductores
{
    public class EditModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public EditModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conductor Conductor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conductor = await _context.Conductores.FindAsync(id);

            if (Conductor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var conductorExistente = await _context.Conductores.FindAsync(Conductor.IdConductor);

            if (conductorExistente == null)
            {
                return NotFound();
            }

            conductorExistente.Nombre = Conductor.Nombre;
            conductorExistente.Apellido = Conductor.Apellido;
            conductorExistente.LicenciaConduccion = Conductor.LicenciaConduccion;
            conductorExistente.Telefono = Conductor.Telefono;
            conductorExistente.Direccion = Conductor.Direccion;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

