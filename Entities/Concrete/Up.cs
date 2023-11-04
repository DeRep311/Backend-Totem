using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Up : IEntity
{
    public string CodigoUbicaciones { get; set; }

    public string CodigoP { get; set; }

    public virtual Plano CodigoPNavigation { get; set; }

    public virtual Ubicacione CodigoUbicacionesNavigation { get; set; }
}
