using FleetManager.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n del contexto de base de datos
builder.Services.AddDbContext<FleetManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FleetManagerContext")));

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.Run();

