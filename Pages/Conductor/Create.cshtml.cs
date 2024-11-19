using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Conductores
{
    public class CreateModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public CreateModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Conductor Conductor { get; set; }

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

            _context.Conductores.Add(Conductor);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

