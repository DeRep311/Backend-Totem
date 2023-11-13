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
        if (_CursoDal.Get(e => e.nombre_curso == cursonew.NombreCurso) != null)
        {
            return new ErrorResult("Curso ya existe");
        }
        else
        {
            _CursoDal.Add(new Curso()
            {
                nombre_curso = cursonew.NombreCurso
            });
            var result = _CursoDal.Get(e => e.nombre_curso == cursonew.NombreCurso);
            foreach (var item in cursonew.Materias)
            {
                if (_MateriaDal.Get(e => e.nombre_materia == item.nombre_materia) == null)
                {
                    _MateriaDal.Add(new Materium()
                    {
                        nombre_materia = item.nombre_materia
                    });
                }
                _cursoMateria.Add(new Cm()
                {
                    id_c = result.id_c,
                    nombre_materia = item.nombre_materia
                });
            }
            return new SuccessResult();
        }

    }

    public IResult Delete(CursoDTO curso)
    {
        var result = this.Get(curso.IdC);
        if (result.Success)
        {
            _CursoDal.Delete(e => e.id_c == curso.IdC);
            foreach (var item in result.Data.Materias)
            {
                _cursoMateria.Delete(e => e.id_c == curso.IdC);
            }
            return new SuccessResult();

        }
        else
        {

            return new ErrorResult("Curso no encontrado");

        }
    }


    public IDataResult<CursoDTO> Get(int IdC)
    {
        var result = _CursoDal.Get(e => e.id_c == IdC);

        if (result != null)
        {

            var materias = _CursoDal.GetYourMaterias(IdC);
            return new SuccessResultData<CursoDTO>(new CursoDTO()
            {
                IdC = result.id_c,
                NombreCurso = result.nombre_curso,
                Materias = materias

            });

        }
        else
        {
            return new ErrorDataResult<CursoDTO>();
        }

    }



    public IDataResult<List<CursoDTO>> GetAll()
    {
        List<CursoDTO> cursosconmateria = new();
        List<Curso> cursos = _CursoDal.GetAll();
        if (cursos == null)
        {
            return new SuccessResultData<List<CursoDTO>>(cursosconmateria);

        }
        else
        {
            foreach (var item in cursos)
            {
                var materias = _CursoDal.GetYourMaterias(item.id_c);
                cursosconmateria.Add(new CursoDTO()
                {
                    IdC = item.id_c,
                    NombreCurso = item.nombre_curso,
                    Materias = materias
                });

            }
            return new SuccessResultData<List<CursoDTO>>(cursosconmateria);
        }

    }

    public IResult Update(CursoDTO Cursonew)
    {
        Curso Cursoold = _CursoDal.Get(e => e.id_c == Cursonew.IdC);
        if (Cursoold == null)
        {
            return new ErrorResult("Curso No encontrado");
        }

        _CursoDal.Update(new Curso()
        {
            id_c = Cursonew.IdC,
            nombre_curso = Cursonew.NombreCurso
        }, e => e.id_c == Cursonew.IdC);


        var result = _cursoMateria.GetAll(e => e.id_c == Cursonew.IdC);
        _cursoMateria.DeleteRaw(result);

        foreach (var item in Cursonew.Materias)
        {
            if (_MateriaDal.Get(e => e.nombre_materia == item.nombre_materia) == null)
            {
                _MateriaDal.Add(new Materium()
                {
                    nombre_materia = item.nombre_materia
                });
            }
            _cursoMateria.Add(new Cm()
            {
                id_c = Cursonew.IdC,
                nombre_materia = item.nombre_materia
            });


        }


        return new SuccessResult();
    }


}