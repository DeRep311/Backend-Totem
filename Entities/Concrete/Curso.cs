using System;
using System.Collections.Generic;
using Core.entities;
namespace DataAccess.Models;

public partial class Curso:IEntity
{
    public int IdC { get; set; }

    public string Generacion { get; set; }

    public string Nombre { get; set; }

    public int Anio { get; set; }
}
