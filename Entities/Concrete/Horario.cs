using System;
using System.Collections.Generic;
using Core.entities;

namespace DataAccess.Models;

public partial class Horario: IEntity
{
    public int IdH { get; set; }

    public string HoraInicio { get; set; }

    public string HoraFinal { get; set; }

    public string NombreDia { get; set; }
}
