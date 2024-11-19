using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FleetManager.Data;
using FleetManager.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FleetManager.Pages.Vehiculo
{
    public class IndexModel : PageModel
    {
        private readonly FleetManagerContext _context;

        public IndexModel(FleetManagerContext context)
        {
            _context = context;
        }
        public IList<Pages_Vehiculo_Index> Vehiculos { get; set; }
        public async Task OnGetAsync()
        {
            Vehiculos = (IList<Pages_Vehiculo_Index>)await _context.Vehiculos.ToListAsync();
        }
    }
}
