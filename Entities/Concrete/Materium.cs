using System;
using System.Collections.Generic;
using Core.entities;
namespace DataAccess.Models;

public partial class Materium:IEntity
{
    public int IdM { get; set; }

    public int? Cedula { get; set; }

    public string Nombre { get; set; }

    public int? IdC { get; set; }
}
