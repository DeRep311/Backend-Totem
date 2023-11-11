using Base.Models;
using Core.DataAccess;
using Microsoft.Identity.Client;

public interface IGroupDal: IEntityRepository<Grupo>
{
  
public List<Estudiante> GetStudent(String grupo);
 public IResult AddStudents(String grupo, List<Estudiante> estudiantes);
 public IResult DeleteStudents(String IdG);
    


     

}