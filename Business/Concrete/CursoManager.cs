using Base.Models;
using DataAccess.DTOs;



public class CursoManager : ICursoServices
{


    private ICursoDal _CursoDal;
    private IMateriaDal _MateriaDal;

    public CursoManager(ICursoDal cursoDal, IMateriaDal MateriaDal)
    {

        _CursoDal = cursoDal;
        _MateriaDal= MateriaDal;

    }


    public IResult Add(Curso cursonew)
    {
        var result= _CursoDal.Get(e=>e==cursonew);
        if (result==null)
        {
            _CursoDal.Add(cursonew);
            return new SuccessResult();
            
        }else{
            return new ErrorResult("Curso ya existente");
        }


    }

    public IResult Delete(int IdC)
    {
      var result= this.Get(IdC);
      if (result.Success)
      {
        _CursoDal.Delete(result.Data);
        return new SuccessResult();
        
      }else{

        return new ErrorResult("Curso no encontrado");

      }
    }

    public IDataResult<Curso> Get(int IdC)
    {
        var result = _CursoDal.Get(e => e.IdC == IdC);
        if (result != null)

        {
            return new SuccessResultData<Curso>(result);

        }else{
            return new ErrorDataResult<Curso>();
        }

    }

    public IDataResult<List<MateriasDTO>> GetMaterias(String Id){

        List<MateriasDTO> ListaMaterias = new();
        ListaMaterias = _MateriaDal.Getbygroup(Id);
        return new SuccessResultData<List<MateriasDTO>>(ListaMaterias);
    }

    public IDataResult<List<Curso>> GetAll()
    {
     List<Curso> cursos = _CursoDal.GetAll();
        if (cursos != null)

        {
            return new SuccessResultData<List<Curso>>(cursos);

        }else{
            return new ErrorDataResult<List<Curso>>();
        }
    }

    public IResult Update(int IdC, Curso Cursonew)
    {
        Curso Cursoold = _CursoDal.Get(e => e.IdC == IdC);
        if (Cursoold == null)
        {
            return new ErrorResult("Curso No encontrado");
        }
        _CursoDal.Update(Cursonew, Cursoold);

        return new SuccessResult();
    }
}