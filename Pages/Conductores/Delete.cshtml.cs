using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Conductores
{
    public class DeleteModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public DeleteModel(FleetManagerContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Conductor = await _context.Conductores.FindAsync(id);

            if (Conductor != null)
            {
                _context.Conductores.Remove(Conductor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}

