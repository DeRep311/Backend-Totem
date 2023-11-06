using Base.Models;

public class EfGroupDal: EfEntityRepositoryBase<Grupo, DatabaseContext>, IGroupDal
 {
    public RepositorySqlRelations relations = new();
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
                    relations.AddGrupoCursoMateria(new GrupoCursoMaterium {
                       NombreMateria= item.NombreMateria, 
                       NombreGrupo= idGroup, 
                        IdC= idCourse});
                    
                
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
                relations.AddGrupoEstudiante(new EstudiaEn {Cedula= item.Cedula, NombreGrupo= idGroup});

               
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
                    relations.removeCursoGrupoMateria(idCourse, item.NombreMateria);
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
    }
}