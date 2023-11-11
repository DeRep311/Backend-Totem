using Base.Models;
using DataAccess.DTOs;


public interface ICursoServices
{


    public IResult Add(CursoDTO cursonew);
    public IResult Delete(CursoDTO IdC);
    public IResult Update(CursoDTO usernew);
 


  

    public IDataResult<CursoDTO> Get(int IdC);

    public IDataResult<List<CursoDTO>> GetAll();




}