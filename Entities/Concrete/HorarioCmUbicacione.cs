using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class HorarioCmUbicacione
{
    public int IdM { get; set; }

    public int IdC { get; set; }

    public string Codigo { get; set; }

    public int IdH { get; set; }

    public virtual Ubicacione CodigoNavigation { get; set; }

    public virtual Horario IdHNavigation { get; set; }

    public virtual Materium IdMNavigation { get; set; }
}
