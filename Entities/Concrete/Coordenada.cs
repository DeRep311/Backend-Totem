using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.entities;

namespace Base.Models;

public partial class Coordenada: IEntity
{
    [NotMapped]
    public int id_c { get; set; }

    public float? coo_x { get; set; }

    public float? CooY { get; set; }

    public string Foto { get; set; }

    public bool? Inicio { get; set; }

    public bool? Final { get; set; }
}
