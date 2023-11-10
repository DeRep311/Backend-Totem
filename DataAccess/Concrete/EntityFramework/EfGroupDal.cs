using Base.Models;

public class EfGroupDal: EfEntityRepositoryBase<Grupo, DatabaseContext>, IGroupDal
 {
    public RepositorySqlRelations relations = new();
    public void AddCourseToGroup(String idGroup, int idCourse)
    {
        // using DatabaseContext context = new();
        // if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
        // {
        //     if (context.Cursos.Any(e => e.IdC == idCourse))
        //     {
        //       var result = context.Cms.Where(e => e.IdC == idCourse).ToList();
             
<<<<<<< Updated upstream
                foreach (var item in result)
                {
                    relations.AddGrupoCursoMateria(new GrupoCursoMaterium {
                       NombreMateria= item.NombreMateria, 
                       NombreGrupo= idGroup, 
                        IdC= idCourse});
                    
                
                }
            }
        }
        context.SaveChanges();
=======
        //         foreach (var item in result)
        //         {
        //             context.GrupoCursoMateria.Add(new GrupoCursoMaterium()
        //             {
        //                 IdC = idCourse,
        //                 NombreMateria = item.NombreMateria,
        //                 NombreGrupo = idGroup
        //             });
        //         context.SaveChanges();
        //         }
        //     }
        // }
        // context.SaveChanges();
        
>>>>>>> Stashed changes
    }

    public void AddStudentToGroup(string idGroup, List<Estudiante> estudiantes)
    {
<<<<<<< Updated upstream
        using DatabaseContext context = new();
        if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
        {
            foreach (var item in estudiantes)
            {
                relations.AddGrupoEstudiante(new EstudiaEn {Cedula= item.Cedula, NombreGrupo= idGroup});

               
            }
        }
=======
        // using DatabaseContext context = new();
        // if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
        // {
        //     foreach (var item in estudiantes)
        //     {
        //         context.EstudiaEns.Add(new EstudiaEn()
        //         {
        //             Cedula = item.Cedula,
        //             NombreGrupo = idGroup
        //         });

        //         context.SaveChanges();
        //     }
        // }
>>>>>>> Stashed changes

    }

    public void DeleteCourseToGroup(string idGroup, int idCourse)
    {
<<<<<<< Updated upstream
       using DatabaseContext context = new();
         if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
         {
              if (context.Cursos.Any(e => e.IdC == idCourse))
              {
                var result = context.Cms.Where(e => e.IdC == idCourse).ToList();
                foreach (var item in result)
                {
                    relations.removeCursoGrupoMateria(idCourse, item.NombreMateria);
                }
              }
         }
=======
    //    using DatabaseContext context = new();
    //      if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
    //      {
    //           if (context.Cursos.Any(e => e.IdC == idCourse))
    //           {
    //             var result = context.Cms.Where(e => e.IdC == idCourse).ToList();
    //             foreach (var item in result)
    //             {
    //                  var result2 = context.GrupoCursoMateria.Where(e => e.NombreMateria == item.NombreMateria && e.NombreGrupo == idGroup).FirstOrDefault();
    //                  context.GrupoCursoMateria.Remove(result2);
    //                     context.SaveChanges();
    //             }
    //           }
         
>>>>>>> Stashed changes
    }

    public void DeleteStudentToGroup(string idGroup, int idStudent)
    {
<<<<<<< Updated upstream
       using DatabaseContext context = new();
         if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
         {
              if (context.Estudiantes.Any(e => e.Cedula == idStudent))
              {
                relations.removeEstudianteGrupo(idStudent, idGroup);
              }
         }
    }

    public void DeleteStudentRawToGroup(String Group){
        using DatabaseContext context = new();
        if (context.Grupos.Any(e=>e.NombreGrupo==Group))
        {
            var result = context.EstudiaEns.Where(e=>e.NombreGrupo==Group).ToList();
            foreach (var item in result)
            {
                relations.removeEstudianteGrupo((int)item.Cedula, Group);
            }
        }
        {
            
        }
=======
    //    using DatabaseContext context = new();
    //      if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
    //      {
    //           if (context.Estudiantes.Any(e => e.Cedula == idStudent))
    //           {
    //             var result = context.EstudiaEns.Where(e => e.Cedula == idStudent && e.NombreGrupo == idGroup).FirstOrDefault();
    //             context.EstudiaEns.Remove(result);
    //             context.SaveChanges();
    //           }
    //      }
    }

    public void DeleteStudentRawToGroup(String Group){
        // using DatabaseContext context = new();
        // if (context.Grupos.Any(e=>e.NombreGrupo==Group))
        // {
        //     var result = context.EstudiaEns.Where(e=>e.NombreGrupo==Group).ToList();
        //     context.EstudiaEns.RemoveRange(result);
        // }
      
>>>>>>> Stashed changes
    }
}