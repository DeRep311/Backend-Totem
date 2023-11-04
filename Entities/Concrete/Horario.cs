using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Horario : IEntity
{
    public int IdH { get; set; }

    public string HoraInicio { get; set; }

    public string HoraFinal { get; set; }

    public string NombreDelDia { get; set; }
}
