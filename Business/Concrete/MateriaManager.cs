using DataAccess.Models;

public class MateriaManager : IMateriaServices

{

    ICursoServices _cursoservices;
    IMateriaDal _materiadal;


    public MateriaManager(ICursoServices cursoServices, IMateriaDal materiadal){
        _cursoservices = cursoServices;
        _materiadal = materiadal;
    }
    public IResult Add(Materium materia, int IdCurso)
    {
        var result = _cursoservices.Get(IdCurso);
        if (result.Success)
        {
            _materiadal.Add(materia);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Curso no encontrado");
        }
    }

    public IResult Add(Materium materia)
    {
        var result = _materiadal.Get(e => e == materia);
        if (result == null)
        {
            _materiadal.Add(materia);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Materia ya existente");
        }
    }

    public IResult Delete(int IdM)
    {
        var result = this.Get(IdM);
        if (result.Success)
        {
            _materiadal.Delete(result.Data);
            return new SuccessResult();

        }
        else
        {

            return new ErrorResult("Materia no encontrada");

        }
    }

    public IDataResult<Materium> Get(int IdM)
    {
        var result = _materiadal.Get(e => e.IdM == IdM);
        if (result != null)

        {
            return new SuccessResultData<Materium>(result);

        }
        else
        {
            return new ErrorDataResult<Materium>();
        }
    }

    public IDataResult<List<Materium>> GetAll()
    {
        List<Materium> ListaMaterias = new();
        ListaMaterias = _materiadal.GetAll();
        return new SuccessResultData<List<Materium>>(ListaMaterias);
    }

    public IResult Update(int IdM, Materium materianew)
    {
        var result = _materiadal.Get(e => e.IdM == IdM);
        if (result != null)
        {
            _materiadal.Update(materianew, result);
            return new SuccessResult();
        }
        else
        {
            return new ErrorResult("Materia no encontrada");
        }
    }
}