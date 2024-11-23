using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;

namespace FleetManager.Pages.Conductores
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }

        public IList<Conductor> Conductores { get; set; }

        public async Task OnGetAsync()
        {
            Conductores = await _context.Conductores.ToListAsync();
        }
    }
}

