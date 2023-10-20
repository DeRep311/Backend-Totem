using DataAccess.Models;

public interface ICursoServices
{


    public IResult Add(Curso cursonew);
    public IResult Delete(int IdC);
    public IResult Update(int IdC, Curso usernew);
    public IDataResult<List<Materium>> GetMaterias(int Id);

    public IDataResult<Curso> Get(int IdC);

    public IDataResult<List<Curso>> GetAll();




}