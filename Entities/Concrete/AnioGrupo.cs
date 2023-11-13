using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class AnioGrupo: IEntity
{
    public string nombre_grupo { get; set; }

    public int? anio { get; set; }
}
