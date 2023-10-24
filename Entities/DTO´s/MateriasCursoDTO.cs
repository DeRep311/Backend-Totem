using System.Collections.Generic;
using Core.entities;
using DataAccess.Models;
namespace DataAccess.DTOs;

public class MateriasDTO:IDTO
{
    public string CursoNombre {get; set;}
    public string NombreMateria {get; set;}
    public int? CedulaProfesor {get; set;}
    public Ubicacione Ubicacion {get; set;}
    public Horario Horarios {get; set;}
    
}