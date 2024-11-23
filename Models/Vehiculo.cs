using System.ComponentModel.DataAnnotations;

namespace FleetManager.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria.")]
        [StringLength(10, ErrorMessage = "La placa no puede exceder 10 caracteres.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        public string Modelo { get; set; }

        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100.")]
        public int Año { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El kilometraje no puede ser negativo.")]
        public int Kilometraje { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }

    }
}


