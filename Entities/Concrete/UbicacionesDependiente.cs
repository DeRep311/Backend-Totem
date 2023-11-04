using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class UbicacionesDependiente : IEntity
{
    public string CodigoUbicacionesDep { get; set; }

    public string CodigoUbicaciones { get; set; }

    public virtual Ubicacione CodigoUbicacionesDepNavigation { get; set; }

    public virtual Ubicacione CodigoUbicacionesNavigation { get; set; }
}
