using System;
using System.Collections.Generic;
using Core.entities;
namespace DataAccess.Models;

public partial class AnioCurso:IEntity
{
    public int Anio { get; set; }

    public int IdC { get; set; }

    public virtual Anio AnioNavigation { get; set; }
}
