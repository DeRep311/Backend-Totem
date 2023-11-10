using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Ubicaciones:IEntity
{
    public string CodigoUbicaciones { get; set; }

    public string Nombre { get; set; }

    public bool Publico { get; set; }

    public bool Privado { get; set; }
}
