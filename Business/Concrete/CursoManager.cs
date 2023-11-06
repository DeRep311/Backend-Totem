using Base.Models;
using DataAccess.DTOs;



public class CursoManager : ICursoServices
{


    private ICursoDal _CursoDal;
    private IMateriaDal _MateriaDal;
    private ICursoMateria _cursoMateria;

    public CursoManager(ICursoDal cursoDal)
    {

        _CursoDal = cursoDal;



    }


    public IResult Add(CursoDTO cursonew)
    {
        var result = _CursoDal.Get(cursonew);
        if (result == null)
        {
            _CursoDal.Add(cursonew);

            return new SuccessResult();

        }
        else
        {
            return new ErrorResult("Curso ya existente");
        }


    }

    public IResult Delete(CursoDTO curso)
    {
        var result = _CursoDal.Get(curso);

        _CursoDal.Delete(curso);



        return new SuccessResult();



    }




    public IDataResult<List<MateriasDTO>> GetMateriasbyGroup(String Id)
    {

        List<MateriasDTO> ListaMaterias = new();
        ListaMaterias = _MateriaDal.Getbygroup(Id);
        return new SuccessResultData<List<MateriasDTO>>(ListaMaterias);
    }

    public IDataResult<List<CursoDTO>> GetAll()
    {

        List<CursoDTO> cursos = _CursoDal.GetAll();


        return new SuccessResultData<List<CursoDTO>>(cursos);


    }




}