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
<<<<<<< Updated upstream
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

=======
       throw new System.NotImplementedException();
>>>>>>> Stashed changes

    }

    public IResult Delete(CursoDTO curso)
    {
<<<<<<< Updated upstream
        var result = _CursoDal.Get(curso);

        _CursoDal.Delete(curso);
=======
        var result = this.Get(curso.IdC);
        if (result.Success)
        {
            _CursoDal.Delete(e=> e.IdC == curso.IdC);
            foreach (var item in result.Data.Materias)
            {
                _cursoMateria.Delete(e=> e.IdC == curso.IdC);
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
                _cursoMateria.Delete(e=> e.IdC == cursowithMaterias.IdC);
                _MateriaDal.Delete(e=> e.NombreMateria == item.NombreMateria);
            }
            _CursoDal.Delete(e=> e.IdC == cursowithMaterias.IdC);
        }
        else
        {
            return new ErrorResult("Curso no encontrado");
        }
        {
            
        }
>>>>>>> Stashed changes



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


<<<<<<< Updated upstream
=======
        _CursoDal.Update(new Curso()
        {
            IdC = Cursonew.IdC,
            NombreCurso = Cursonew.NombreCurso
        }, e=> e.IdC == Cursonew.IdC);


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
>>>>>>> Stashed changes


}