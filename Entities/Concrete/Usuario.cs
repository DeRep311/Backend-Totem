using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.entities;

namespace DataAccess.Models;

public partial class Usuario:IEntity
{
    public int Cedula { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int Telefono { get; set; }

    public string Direccion { get; set; }

    public int Pin { get; set; }

    public bool? Administrador { get; set; }

    public bool? Operador { get; set; }

    [NotMapped]
    public bool? Docente {get; set;}
    [NotMapped]
    public bool? Estudiante {get; set;}
}
