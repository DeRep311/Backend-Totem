using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class HorarioCmUbicacione: IEntity
{
    public int IdM { get; set; }

    public int IdC { get; set; }

    public int IdH { get; set; }

    public string Codigo { get; set; }
}
