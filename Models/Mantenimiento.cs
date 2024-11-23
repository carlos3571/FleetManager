using System.ComponentModel.DataAnnotations;

namespace FleetManager.Models
{
    public class Mantenimiento
    {
        [Key]
        public int IdMantenimiento { get; set; }

        [Required]
        public int IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }

        [Required(ErrorMessage = "La fecha de mantenimiento es obligatoria.")]
        public DateTime FechaMantenimiento { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El costo no puede ser negativo.")]
        public decimal Costo { get; set; }
    }
}

