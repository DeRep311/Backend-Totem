using Base.Models;
using Core.DataAccess;

public interface IGroupDal: IEntityRepository<Grupo>
{
     public void AddCourseToGroup(String idGroup, int idCourse);

     public void DeleteCourseToGroup(String idGroup, int idCourse);

     public void AddStudentToGroup(String idGroup, List<Estudiante> idStudent);

     public void DeleteStudentToGroup(String idGroup, int idStudent);
     public void DeleteStudentRawToGroup(String Group);

    


     

}