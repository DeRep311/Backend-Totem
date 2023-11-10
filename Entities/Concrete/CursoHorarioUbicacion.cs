using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class CursoHorarioUbicacion: IEntity
{
    public int IdH { get; set; }

    public string NombreGrupo { get; set; }

    public string NombreMateria { get; set; }

    public int IdC { get; set; }

    public string CodigoUbicaciones { get; set; }

   
}
