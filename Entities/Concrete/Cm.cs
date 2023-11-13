using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Cm: IEntity
{
    public int id_c { get; set; }

    public string nombre_materia { get; set; }

}
