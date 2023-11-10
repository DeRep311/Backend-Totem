using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Imparte:IEntity
{
    public int? Cedula { get; set; }

    public string NombreMateria { get; set; }

    public string NombreGrupo { get; set; }

    public int IdC { get; set; }

    public int? IdH { get; set; }
}
