using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.VehiculosView
{
    public class CreateModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public CreateModel(FleetManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [BindProperty]
        public Vehiculo Vehiculo { get; set; }

        public IActionResult OnGet()
        {
            // Inicializar la propiedad para evitar problemas de referencia nula
            Vehiculo = new Vehiculo();
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
                _context.Vehiculos.Add(Vehiculo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Manejar errores al guardar
                ModelState.AddModelError(string.Empty, $"Error al guardar el vehículo: {ex.Message}");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
