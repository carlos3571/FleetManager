using System.ComponentModel.DataAnnotations;

namespace FleetManager.Models;

public class Asignacion
{
    private object conductor;

    [Key]
    public int IdAsignacion { get; set; }

    [Required]
    public int IdVehiculo { get; set; } // Relación con Vehículo

    [Required]
    public int IdConductor { get; set; } // Relación con Conductor

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; } // Fecha fin puede ser opcional.
    public object? Vehiculo { get; internal set; }

    public Asignacion(object? vehiculo)
    {
        Vehiculo = vehiculo;
    }

    public object GetConductor()
    {
        return conductor;
    }

    internal void SetConductor(object value)
    {
        conductor = value;
    }

    //IdVehiculo y IdConductor representan relaciones con las tablas respectivas.
}
