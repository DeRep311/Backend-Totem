using System;
using System.Collections.Generic;
using Core.entities;
namespace DataAccess.Models;

public partial class Ubicacione:IEntity
{
    public string Codigo { get; set; }

    public string Nombre { get; set; }

    public string CodigoP { get; set; }

    public ulong Publico { get; set; }

    public ulong Privado { get; set; }

    public int PlanoImg { get; set; }

    public virtual Plano Plano { get; set; }

    public virtual ICollection<Coordenada> Ids { get; set; } = new List<Coordenada>();
}
