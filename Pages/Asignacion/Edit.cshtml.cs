using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Pages.Asignaciones
{
    public class EditModel : PageModel
    {
        private readonly FleetManagerContext _context;

        [BindProperty]
        public Asignacion Asignacion { get; set; }

        public EditModel(FleetManagerContext context)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Asignacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Asignaciones.Any(e => e.IdAsignacion == Asignacion.IdAsignacion))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

