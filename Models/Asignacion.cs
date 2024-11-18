﻿using System.ComponentModel.DataAnnotations;
using FleetManager.Data;


public class Asignacion
{
    [Key]
    public int IdAsignacion { get; set; }

    [Required]
    public int IdVehiculo { get; set; } // Relación con Vehículo

    [Required]
    public int IdConductor { get; set; } // Relación con Conductor

    [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
    public DateTime FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; } // Fecha fin puede ser opcional.

    //IdVehiculo y IdConductor representan relaciones con las tablas respectivas.
}
