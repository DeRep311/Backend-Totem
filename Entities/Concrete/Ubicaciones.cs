using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Ubicaciones:IEntity
{
    public readonly object Privado;

    public string codigo_ubicaciones { get; set; }

    public string nombre { get; set; }

    public bool publico { get; set; }

    public bool privado { get; set; }
}
