using FleetManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n del contexto de base de datos
builder.Services.AddDbContext<FleetManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FleetManagerContext")));

// Registrar servicios de autenticaci�n y autorizaci�n
builder.Services.AddAuthentication(); // Configurar la autenticaci�n aqu� si es necesaria
builder.Services.AddAuthorization();  // Registrar la autorizaci�n

// Habilitar Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Habilitar la b�squeda de p�ginas Razor
app.MapRazorPages();

app.Run();
