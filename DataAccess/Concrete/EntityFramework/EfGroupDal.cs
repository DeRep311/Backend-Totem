using Base.Models;

public class EfGroupDal: EfEntityRepositoryBase<Grupo, DatabaseContext>, IGroupDal
 {
    public void AddCourseToGroup(String idGroup, int idCourse)
    {
        using DatabaseContext context = new();
        if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
        {
            if (context.Cursos.Any(e => e.IdC == idCourse))
            {
              var result = context.Cms.Where(e => e.IdC == idCourse).ToList();
             
                foreach (var item in result)
                {
                    context.GrupoCursoMateria.Add(new GrupoCursoMaterium()
                    {
                        IdC = idCourse,
                        NombreMateria = item.NombreMateria,
                        NombreGrupo = idGroup
                    });
                context.SaveChanges();
                }
            }
        }
        context.SaveChanges();
    }

    public void AddStudentToGroup(string idGroup, List<Estudiante> estudiantes)
    {
        using DatabaseContext context = new();
        if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
        {
            foreach (var item in estudiantes)
            {
                context.EstudiaEns.Add(new EstudiaEn()
                {
                    Cedula = item.Cedula,
                    NombreGrupo = idGroup
                });

                context.SaveChanges();
            }
        }

    }

    public void DeleteCourseToGroup(string idGroup, int idCourse)
    {
       using DatabaseContext context = new();
         if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
         {
              if (context.Cursos.Any(e => e.IdC == idCourse))
              {
                var result = context.Cms.Where(e => e.IdC == idCourse).ToList();
                foreach (var item in result)
                {
                     var result2 = context.GrupoCursoMateria.Where(e => e.NombreMateria == item.NombreMateria && e.NombreGrupo == idGroup).FirstOrDefault();
                     context.GrupoCursoMateria.Remove(result2);
                        context.SaveChanges();
                }
              }
         }
    }

    public void DeleteStudentToGroup(string idGroup, int idStudent)
    {
       using DatabaseContext context = new();
         if (context.Grupos.Any(e => e.NombreGrupo == idGroup))
         {
              if (context.Estudiantes.Any(e => e.Cedula == idStudent))
              {
                var result = context.EstudiaEns.Where(e => e.Cedula == idStudent && e.NombreGrupo == idGroup).FirstOrDefault();
                context.EstudiaEns.Remove(result);
                context.SaveChanges();
              }
         }
    }

    public void DeleteStudentRawToGroup(String Group){
        using DatabaseContext context = new();
        if (context.Grupos.Any(e=>e.NombreGrupo==Group))
        {
            var result = context.EstudiaEns.Where(e=>e.NombreGrupo==Group).ToList();
            context.EstudiaEns.RemoveRange(result);
        }
        {
            
        }
    }
}