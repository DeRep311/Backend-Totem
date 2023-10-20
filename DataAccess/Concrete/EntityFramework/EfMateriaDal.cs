using System.Runtime.CompilerServices;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class EfMateriaDal : EfEntityRepositoryBase<Materium, DatabaseContext>, IMateriaDal
{

    public MateriasDTO Get(int id)
    {
        using (var context = new DatabaseContext())
        {
            var materia = context.HorarioCmUbicaciones
                .Include(x => x.IdMNavigation)
                .Include(x => x.IdHNavigation)
                .Include(x => x.CodigoNavigation)
                .FirstOrDefault(x => x.IdM == id);

            var curso = from c in context.Cursos
                        where c.IdC == materia.IdMNavigation.IdC
                        select new  { 
                            
                            Nombre= c.Nombre,
                            Anio = c.Anio,
                            Generacion = c.Generacion
                            
                             };
                        
            var materiaDTO = new MateriasDTO
            {
                CursoNombre = curso.First().Nombre,
                NombreMateria = materia.IdMNavigation.Nombre,
                CedulaProfesor = materia.IdMNavigation.Cedula,
                Ubicacion = materia.CodigoNavigation,
                Horarios = materia.IdHNavigation,
            };

            return materiaDTO;
        }
    }



}