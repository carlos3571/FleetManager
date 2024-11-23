using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.VehiculosView
{
    public class DeleteModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public DeleteModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehiculo Vehiculo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo = await _context.Vehiculos.FindAsync(id);

            if (Vehiculo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehiculo = await _context.Vehiculos.FindAsync(id);

            if (Vehiculo != null)
            {
                _context.Vehiculos.Remove(Vehiculo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}

