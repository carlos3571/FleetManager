using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FleetManager.Data;
using FleetManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Pages.Mantenimientos
{
    public class CreateModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public CreateModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mantenimiento Mantenimiento { get; set; }

        public SelectList Vehiculos { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Vehiculos = new SelectList(await _context.Vehiculos.ToListAsync(), "IdVehiculo", "Placa");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mantenimientos.Add(Mantenimiento);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
