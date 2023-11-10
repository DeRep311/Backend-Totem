using System;
using System.Collections.Generic;
using Base.Models;
using Core.entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

public class CursoDTO: IDTO
 {
    public String NombreCurso { get; set; }
    public int IdC { get; set; }
    public List<Materium> Materias { get; set; }

    
}