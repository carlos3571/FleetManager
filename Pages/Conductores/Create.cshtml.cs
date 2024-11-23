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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [BindProperty]
        public Conductor Conductor { get; set; }

        public IActionResult OnGet()
        {
            // Inicializar la propiedad para evitar null cuando sea necesario
            Conductor = new Conductor();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Conductores.Add(Conductor);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al guardar el conductor: " + ex.Message);
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
