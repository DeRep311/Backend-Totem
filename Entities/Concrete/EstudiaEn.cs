using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class EstudiaEn: IEntity
{
    public int? Cedula { get; set; }

    public string nombre_grupo { get; set; }

  
}
