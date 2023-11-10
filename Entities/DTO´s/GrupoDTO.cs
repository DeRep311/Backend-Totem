using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Base.Models;
using Core.entities;
using DataAccess.DTOs;

public class GrupoDTO:IDTO
{
    public String NombreGrupo {get; set;}

   public String NombreCurso {get; set;}



    #nullable enable
[NotMapped]
    public int Idc {get; set;}
    [NotMapped]

   public List<MateriasDTO>? Materias {get; set;}

   public List<Estudiante>? Estudiantes {get; set;}
    
}