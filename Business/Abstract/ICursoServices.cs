using Base.Models;
using DataAccess.DTOs;


public interface ICursoServices
{


    public IResult Add(CursoDTO cursonew);
    public IResult Delete(CursoDTO IdC);
  
  

  

    public IDataResult<List<CursoDTO>> GetAll();




}