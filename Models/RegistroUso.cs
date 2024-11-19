using System.ComponentModel.DataAnnotations;

namespace FleetManager.Models
{
    public class RegistroUso
    {
        public int IdRegistro { get; set; }

        [Required]
        public int IdVehiculo { get; set; }
        public Vehiculo Vehiculo { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El kilometraje inicial no puede ser negativo.")]
        public int KilometrajeInicio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El kilometraje final no puede ser negativo.")]
        [Compare("KilometrajeInicio", ErrorMessage = "El kilometraje final debe ser mayor o igual al inicial.")]
        public int KilometrajeFin { get; set; }
    }
}


