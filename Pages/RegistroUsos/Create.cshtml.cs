using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FleetManager.Data;
using FleetManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.Pages.RegistrosUso
{
    public class CreateModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public CreateModel(FleetManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RegistroUso RegistroUso { get; set; }

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
                Vehiculos = new SelectList(await _context.Vehiculos.ToListAsync(), "IdVehiculo", "Placa");
                return Page();
            }

            _context.RegistroUsos.Add(RegistroUso);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
