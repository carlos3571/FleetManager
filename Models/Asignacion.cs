using System.ComponentModel.DataAnnotations;

namespace FleetManager.Models
{
    public class Asignacion
    {
        [Key]
        public int IdAsignacion { get; set; }

        [Required]
        public int IdVehiculo { get; set; } // Relación con Vehiculo
        public Vehiculo Vehiculo { get; set; } // Navegación pública

        [Required]
        public int IdConductor { get; set; } // Relación con Conductor
        public Conductor Conductor { get; set; } // Navegación pública

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; } // Fecha fin puede ser opcional.      
        

        //IdVehiculo y IdConductor representan relaciones con las tablas respectivas.
    }
}
