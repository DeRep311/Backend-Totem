using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Cm: IEntity
{
    public int IdC { get; set; }

    public string NombreMateria { get; set; }

    public virtual Curso IdCNavigation { get; set; }

    public virtual Materium NombreMateriaNavigation { get; set; }
}
