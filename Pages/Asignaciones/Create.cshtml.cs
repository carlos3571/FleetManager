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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void OnGet()
        {
            // Inicializar el objeto para evitar problemas con referencias nulas
            Asignacion = new Asignacion();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _context.Asignaciones.Add(Asignacion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejo de errores para evitar fallos no controlados
                ModelState.AddModelError(string.Empty, $"Error al guardar la asignación: {ex.Message}");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
