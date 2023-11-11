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



    public List<Materium>? Materias {get; set;}
    public int Idc {get; set;}


   public List<Estudiante>? Estudiantes {get; set;}
    
}