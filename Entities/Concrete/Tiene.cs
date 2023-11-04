using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Tiene : IEntity
{
    public string CodigoUbicaciones { get; set; }

    public int? IdC { get; set; }

    public virtual Ubicacione CodigoUbicacionesNavigation { get; set; }

    public virtual Coordenada IdCNavigation { get; set; }
}
