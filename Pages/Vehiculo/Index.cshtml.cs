using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        Vehiculos = await _context.Vehiculos.ToListAsync();
    }
}

