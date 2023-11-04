using System;
using System.Collections.Generic;
using Core.entities;

namespace Base.Models;

public partial class Curso : IEntity
{
    public int IdC { get; set; }

    public string NombreCurso { get; set; }
}
