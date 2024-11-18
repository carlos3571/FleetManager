using System.ComponentModel.DataAnnotations;

public class Mantenimiento
{
    [Key]
    public int IdMantenimiento { get; set; }

    [Required]
    public int IdVehiculo { get; set; } // Relación con Vehículo

    [Required(ErrorMessage = "La fecha del mantenimiento es obligatoria.")]
    public DateTime FechaMantenimiento { get; set; }

    [MaxLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres.")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "El costo es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser mayor o igual a 0.")]
    public int Costo { get; set; }
}
