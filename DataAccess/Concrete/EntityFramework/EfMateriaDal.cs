using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Base.Models;
using DataAccess.DTOs;

using Microsoft.EntityFrameworkCore;

public class EfMateriaDal : EfEntityRepositoryBase<Materium, DatabaseContext>, IMateriaDal
{

    public List<MateriasDTO> Getbygroup(string NombreGrupo)
    {
        using var context = new DatabaseContext();
        if (context.Grupos.Any(x => x.NombreGrupo == NombreGrupo))
        {
            var querymaterias=context.GrupoCursoMateria.Where(x=> x.NombreGrupo== NombreGrupo).ToList();
            List<MateriasDTO> materiadocente = new ();
            foreach(var m in querymaterias){
                var queryprofesor = from docente in context.Impartes
                    where docente.NombreMateria == m.NombreMateria.DefaultIfEmpty()
                    join infodocente in context.Docentes on docente.Cedula equals infodocente.Cedula
                    join horario in context.HorarioGrupoCursos on m.NombreMateria equals horario.NombreMateria
                    join infohorario in context.Horarios.ToList() on horario.IdH equals infohorario.IdH
                    join Ubicaciones in context.CursoHorarioUbicacions on horario.IdH equals Ubicaciones.IdH
                  
                    select new MateriasDTO
                    {
                        NombreMateria = docente.NombreMateria,
                        Cedula = docente.Cedula,
                        NombreDocente = infodocente.CedulaNavigation.Nombre,
                        ApellidoDocente = infodocente.CedulaNavigation.Apellido,
                        Ubicacion = Ubicaciones.CodigoUbicaciones,
                        Horarios = infohorario
                    };
                materiadocente.Add(queryprofesor.FirstOrDefault());
                    
              
            }
            

      
        }
        else
        {
            return null;
        }
        {
          return null;
        }
    }



}