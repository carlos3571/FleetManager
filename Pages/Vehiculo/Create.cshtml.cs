using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Vehiculos
{
    public class CreateModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public CreateModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vehiculo Vehiculo { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vehiculos.Add(Vehiculo);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

