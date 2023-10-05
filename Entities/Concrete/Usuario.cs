using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Usuario: IEntity
{
    public int Cedula { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int Telefono { get; set; }

    public string Direccion { get; set; }

    public int Pin { get; set; }
}
