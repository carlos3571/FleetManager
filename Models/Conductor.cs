using System.ComponentModel.DataAnnotations;

namespace FleetManager.Models
{
    public class Conductor
    {
        public int IdConductor { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(50, ErrorMessage = "El apellido no puede exceder 50 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La licencia de conducción es obligatoria.")]
        public string LicenciaConduccion { get; set; }

        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}

}
