using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class HorarioGrupoCurso : IEntity
{
    public int IdH { get; set; }

    public string NombreGrupo { get; set; }

    public string NombreMateria { get; set; }

    public int? IdC { get; set; }

    public virtual Horario IdHNavigation { get; set; }
}
