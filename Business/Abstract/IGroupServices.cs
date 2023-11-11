using Base.Models;

public interface IGroupServices
{



    public IDataResult<List<GrupoDTO>> GetAll();

    public IDataResult<GrupoDTO> Get(String IdG);

    public IResult CreateGroup(GrupoDTO grupo);

    public IResult DeleteGroup(String IdG);

    public IResult UpdateGroup(String IdG, GrupoDTO gruponew);

    public IDataResult<List<Estudiante>> AddStudents (String IdG, List<Estudiante> estudiantes);
    


}