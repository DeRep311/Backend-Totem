using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Coordenada: IEntity
{
    public int IdC { get; set; }

    public float? CooX { get; set; }

    public float? CooY { get; set; }

    public string Foto { get; set; }

    public bool? Inicio { get; set; }

    public bool? Final { get; set; }
}
