using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Asignaciones
{
    public class CreateModel : PageModel
    {
        private readonly FleetManagerContext _context;

        [BindProperty]
        public Asignacion Asignacion { get; set; }

        public CreateModel(FleetManagerContext context)
        {
            _context = context;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Asignaciones.Add(Asignacion);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

