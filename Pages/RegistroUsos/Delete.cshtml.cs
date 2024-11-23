using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.RegistrosUso
{
    public class DeleteModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public DeleteModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegistroUso RegistroUso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RegistroUso = await _context.RegistroUsos
                .Include(r => r.Vehiculo)
                .FirstOrDefaultAsync(r => r.IdRegistro == id);

            if (RegistroUso == null)
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

            RegistroUso = await _context.RegistroUsos.FindAsync(id);

            if (RegistroUso != null)
            {
                _context.RegistroUsos.Remove(RegistroUso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}
