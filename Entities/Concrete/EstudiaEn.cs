using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class EstudiaEn : IEntity
{
    public int? Cedula { get; set; }

    public string NombreGrupo { get; set; }

    public virtual Grupo NombreGrupoNavigation { get; set; }
}
