using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Asignaciones
{
    public class DeleteModel : PageModel
    {
        private readonly FleetManagerContext _context;

        [BindProperty]
        public Asignacion Asignacion { get; set; }

        public DeleteModel(FleetManagerContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Asignacion = await _context.Asignaciones.FindAsync(id);

            if (Asignacion == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Asignacion == null)
            {
                return NotFound();
            }

            _context.Asignaciones.Remove(Asignacion);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
