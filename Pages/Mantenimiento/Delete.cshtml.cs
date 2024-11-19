using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Mantenimientos
{
    public class DeleteModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public DeleteModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mantenimiento Mantenimiento { get; set; }

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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mantenimiento = await _context.Mantenimientos.FindAsync(id);

            if (Mantenimiento != null)
            {
                _context.Mantenimientos.Remove(Mantenimiento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}

