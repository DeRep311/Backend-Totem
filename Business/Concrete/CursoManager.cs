using Base.Models;
using DataAccess.DTOs;



public class CursoManager : ICursoServices
{


    private ICursoDal _CursoDal;
    private IMateriaDal _MateriaDal;
    private ICursoMateria _cursoMateria;

    public CursoManager(ICursoDal cursoDal, IMateriaDal MateriaDal, ICursoMateria cursoMateria)
    {

        _CursoDal = cursoDal;
        _MateriaDal = MateriaDal;
        _cursoMateria = cursoMateria;
        

    }


    public IResult Add(CursoDTO cursonew)
    {
        var result = _CursoDal.Get(e => e.IdC == cursonew.IdC);
        if (result == null)
        {
            _CursoDal.Add(new Curso()
            {
                NombreCurso = cursonew.NombreCurso,
                IdC = cursonew.IdC
            });
            foreach (var item in cursonew.Materias)
            {
                if (_MateriaDal.Get(e => e.NombreMateria == item.NombreMateria) == null)
                {
                    _MateriaDal.Add(new Materium()
                    {
                        NombreMateria = item.NombreMateria,
                    });

                }
                _cursoMateria.Add(new Cm()
                {
                    IdC = cursonew.IdC,
                    NombreMateria = item.NombreMateria
                });
            }
            return new SuccessResult();

        }
        else
        {
            return new ErrorResult("Curso ya existente");
        }


    }

    public IResult Delete(CursoDTO curso)
    {
        var result = this.Get(curso.IdC);
        if (result.Success)
        {
            _CursoDal.Delete(new Curso()
            {
                IdC = result.Data.IdC,
                NombreCurso = result.Data.NombreCurso
                
            });
            foreach (var item in result.Data.Materias)
            {
                _cursoMateria.Delete(new Cm()
                {
                    IdC = curso.IdC,
                    NombreMateria = item.NombreMateria
                });
            }
            return new SuccessResult();

        }
        else
        {

            return new ErrorResult("Curso no encontrado");

        }
    }

    public IResult DeleteCourseWithSomeMaterias(CursoDTO cursowithMaterias){
        var result = this.Get(cursowithMaterias.IdC);
        if (result != null)
        {
            foreach (var item in result.Data.Materias)
            {
                _cursoMateria.Delete(new Cm()
                {
                    IdC = cursowithMaterias.IdC,
                    NombreMateria = item.NombreMateria
                });
                _MateriaDal.Delete(new Materium(){
                    NombreMateria = item.NombreMateria
                });
            }
            _CursoDal.Delete(new Curso()
            {
                IdC = result.Data.IdC,
                NombreCurso = result.Data.NombreCurso

            });
        }
        else
        {
            return new ErrorResult("Curso no encontrado");
        }
        {
            
        }



        return new SuccessResult();

    }

    public IDataResult<CursoDTO> Get(int IdC)
    {
        var result = _CursoDal.Get(e => e.IdC == IdC);

        if (result != null)
        {

            var materias = _CursoDal.GetYourMaterias(IdC);
            return new SuccessResultData<CursoDTO>(new CursoDTO(){
                IdC = result.IdC,
                NombreCurso = result.NombreCurso,
                Materias = materias
            
            });

        }
        else
        {
            return new ErrorDataResult<CursoDTO>();
        }

    }

    public IDataResult<List<MateriasDTO>> GetMateriasbyGroup(String Id)
    {

        List<MateriasDTO> ListaMaterias = new();
        ListaMaterias = _MateriaDal.Getbygroup(Id);
        return new SuccessResultData<List<MateriasDTO>>(ListaMaterias);
    }

    public IDataResult<List<CursoDTO>> GetAll()
    {
        List<CursoDTO> cursosconmateria = new();
        List<Curso> cursos = _CursoDal.GetAll();
        if (cursos == null)
        {
            return new SuccessResultData<List<CursoDTO>>(cursosconmateria);
            
        }else{
        foreach (var item in cursos)
        {
            var materias = _CursoDal.GetYourMaterias(item.IdC);
            cursosconmateria.Add(new CursoDTO()
            {
                IdC = item.IdC,
                NombreCurso = item.NombreCurso,
                Materias = materias
            });
            
        }
        return new SuccessResultData<List<CursoDTO>>(cursosconmateria);
        }
        
    }

    public IResult Update(CursoDTO Cursonew)
    {
        Curso Cursoold = _CursoDal.Get(e => e.IdC == Cursonew.IdC);
        if (Cursoold == null)
        {
            return new ErrorResult("Curso No encontrado");
        }

        _CursoDal.Update(new Curso()
        {
            IdC = Cursonew.IdC,
            NombreCurso = Cursonew.NombreCurso
        }, Cursoold);


        var result = _cursoMateria.GetAll(e => e.IdC == Cursonew.IdC);
        _cursoMateria.DeleteRaw(result);

        foreach (var item in Cursonew.Materias)
        {
           if (_MateriaDal.Get(e => e.NombreMateria == item.NombreMateria) == null)
           {
               _MateriaDal.Add(new Materium(){
                   NombreMateria = item.NombreMateria
               });
           }
              _cursoMateria.Add(new Cm(){
                IdC = Cursonew.IdC,
                NombreMateria = item.NombreMateria
              });   
             
        
        }
       

        return new SuccessResult();
    }


}