using Base.Models;
using DataAccess.DTOs;


public interface ICursoServices
{


    public IResult Add(Curso cursonew);
    public IResult Delete(int IdC);
    public IResult Update(int IdC, Curso usernew);
    public IDataResult<List<MateriasDTO>> GetMaterias(String Id);

    public IDataResult<Curso> Get(int IdC);

    public IDataResult<List<Curso>> GetAll();




}