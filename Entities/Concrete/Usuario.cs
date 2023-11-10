using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.entities;

namespace Base.Models;

public partial class Usuario : IEntity
{
    public int Cedula { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int Telefono { get; set; }

    public int Direccion { get; set; }

    public int Pin { get; set; }

    [NotMapped]
    public string Rol { get; set; }
}
