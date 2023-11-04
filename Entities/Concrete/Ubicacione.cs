using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Ubicacione : IEntity
{
    public string CodigoUbicaciones { get; set; }

    public string Nombre { get; set; }

    public ulong Publico { get; set; }

    public ulong Privado { get; set; }

    public List<Coordenada> IdCs { get; set; }
}
