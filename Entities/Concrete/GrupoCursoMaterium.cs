using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class GrupoCursoMaterium:IEntity
{
    public string NombreGrupo { get; set; }

    public string NombreMateria { get; set; }

    public int IdC { get; set; }

    
}
