using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Coordenada :IEntity
{
    public int Id { get; set; }

    public float CooX { get; set; }

    public float CooY { get; set; }

    public int Foto { get; set; }
    
    public bool Inicio {get; set;}

    public bool Final {get; set;}

    public virtual ICollection<Ubicacione> Codigos { get; set; } = new List<Ubicacione>();

    

}
