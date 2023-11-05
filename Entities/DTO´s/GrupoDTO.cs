using System;
using System.Collections.Generic;
using Base.Models;
using Core.entities;
using DataAccess.DTOs;

public class GrupoDTO:IDTO
{
    public String NombreGrupo {get; set;}

   public String NombreCurso {get; set;}



    #nullable enable

    public int Idc {get; set;}

   public List<MateriasDTO>? Materias {get; set;}

   public List<Estudiante>? Estudiantes {get; set;}
    
}