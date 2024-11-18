using System.ComponentModel.DataAnnotations;


public class Vehiculo
{
    [Key]
    public int IdVehiculo { get; set; }
    [Required]
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public int Kilometraje { get; set; }
}
