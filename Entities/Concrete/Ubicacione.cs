using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.entities;

namespace Base.Models;

public partial class Ubicacione : IEntity
{
    public string CodigoUbicaciones { get; set; }

    public string Nombre { get; set; }

    public bool Publico { get; set; }

    public bool Privado { get; set; }

    [NotMapped]
    public List<Coordenada> IdCs { get; set; }
}
