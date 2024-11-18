
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Pages;
using FleetManager.Models;

[Authorize]
public class IndexModel : PageModel
{
    private readonly FleetManagerContext _context;

    public IndexModel(FleetManagerContext context)
    {
        _context = context;
    }

    public IList<Vehiculo> Vehiculos { get; set; }

    public async Task OnGetAsync()
    {
        try
        {
            Vehiculos = await _context.Vehiculos.ToListAsync();
        }
        catch (Exception ex)
        {
            // Manejar la excepción, por ejemplo, registrar el error o mostrar un mensaje al usuario
            Console.Error.WriteLine("Error al obtener los vehículos: " + ex.Message);
            Vehiculos = new List<Vehiculo>(); // Asignar una lista vacía para evitar errores en la vista
        }
    }
}
