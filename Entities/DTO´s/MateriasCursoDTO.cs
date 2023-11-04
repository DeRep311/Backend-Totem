using System.Collections.Generic;
using Base.Models;
using Core.entities;

namespace DataAccess.DTOs;

public class MateriasDTO:IDTO
{
    public string CursoNombre {get; set;}
    public string NombreMateria {get; set;}
    public int? Cedula {get; set;}
    public string NombreDocente {get; set;}
    public string ApellidoDocente {get; set;}
    
    public Ubicacione Ubicacion {get; set;}
    public Horario Horarios {get; set;}
    
}