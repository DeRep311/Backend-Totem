
using System;
using System.ComponentModel.DataAnnotations;
using Core.entities;

public class Users : IEntity
{

    [Key]
    public int Cedula { get; set; }

    public int Pin { get; set; }
    public int? Telefono { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Direccion { get; set; }


    public string? Type { get; set; }


}