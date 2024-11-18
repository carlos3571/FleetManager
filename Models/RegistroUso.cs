using System.ComponentModel.DataAnnotations;

public class RegistroUso
{
    [Key]
    public int IdRegistro { get; set; }

    [Required]
    public int IdVehiculo { get; set; } // Relación con Vehículo

    [Required(ErrorMessage = "La fecha del registro es obligatoria.")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "El kilometraje inicial es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El kilometraje inicial debe ser mayor o igual a 0.")]
    public int KilometrajeInicio { get; set; }

    [Required(ErrorMessage = "El kilometraje final es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El kilometraje final debe ser mayor o igual a 0.")]
    public int KilometrajeFin { get; set; }
}

//KilometrajeFin debe ser mayor o igual a KilometrajeInicio (esto podría validarse en el controlador o el servicio).
//Relación con Vehículo a través de IdVehiculo.

