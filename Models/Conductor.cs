using System.ComponentModel.DataAnnotations;


public class Conductor
{
    [Key]
    public int IdConductor { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(50)]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [MaxLength(50)]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El número de licencia es obligatorio.")]
    [MaxLength(20)]
    public string LicenciaConduccion { get; set; }

    [Phone(ErrorMessage = "El teléfono debe tener un formato válido.")]
    public int Telefono { get; set; }

    [MaxLength(100)]
    public string Direccion { get; set; }
}
