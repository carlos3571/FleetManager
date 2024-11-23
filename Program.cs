using FleetManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración del contexto de base de datos
builder.Services.AddDbContext<FleetManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FleetManagerContext")));

// Registrar servicios de autenticación y autorización
builder.Services.AddAuthentication(); // Configurar la autenticación aquí si es necesaria
builder.Services.AddAuthorization();  // Registrar la autorización

// Habilitar Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Habilitar la búsqueda de páginas Razor
app.MapRazorPages();

app.Run();
