using System;
using System.Collections.Generic;
using Core.entities;
namespace DataAccess.Models;

public partial class Plano:IEntity
{
    public string CodigoP { get; set; }

    public int PlanoImg { get; set; }

    public virtual ICollection<Ubicacione> Ubicaciones { get; set; } = new List<Ubicacione>();
}
