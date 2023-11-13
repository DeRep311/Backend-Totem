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

    public float? coo_y { get; set; }

    public string foto { get; set; }

    public bool? Inicio { get; set; }

    public bool? Final { get; set; }
}
