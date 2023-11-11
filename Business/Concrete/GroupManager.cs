
using Base.Models;
using Microsoft.Identity.Client;

public class GroupManager : IGroupServices
{

    IGroupDal _groupDal;
    IMateriaDal _materiaDal;
    IGrupoCursoMateriaDal _grupoCursoMateriaDal;

    ICursoDal _cursoDal;
    public GroupManager(IGroupDal groupDal, IMateriaDal materiaDal, ICursoDal cursoDal, IGrupoCursoMateriaDal grupoCursoMateriaDal)
    {
        _groupDal = groupDal;
        _materiaDal = materiaDal;
        _cursoDal = cursoDal;
        _grupoCursoMateriaDal = grupoCursoMateriaDal;
    }

    public IDataResult<List<Estudiante>> AddStudents(string IdG, List<Estudiante> estudiantes)
    {
        var result = _groupDal.Get(e => e.nombre_grupo == IdG);
        if (result != null)

        {
            var response = _groupDal.AddStudents(IdG, estudiantes);
            if (response.Success)
            {
                return new SuccessResultData<List<Estudiante>>(estudiantes, response.Message);
            }
            else
            {
                return new ErrorDataResult<List<Estudiante>>(response.Message, null);
            }

        }else
        return new ErrorDataResult<List<Estudiante>>("Grupo no encontrado", null);
    }

    public IResult CreateGroup(GrupoDTO grupo)
    {
 

        var result = _groupDal.Get(e => e.nombre_grupo == grupo.NombreGrupo);
        if (result == null)
        {
            _groupDal.Add(new Grupo()
            {
                nombre_grupo = grupo.NombreGrupo
            });
            var result2 = _cursoDal.Get(e => e.IdC == grupo.Idc);
            if (result2 != null)
            {
                _grupoCursoMateriaDal.Add(new GrupoCursoMaterium()
                {
                    IdC = grupo.Idc,
                    nombre_grupo = grupo.NombreGrupo,

                });

                return new SuccessResult();




            }
            else
            {
                return new ErrorResult("Curso no encontrado");
            }


        }
        return new SuccessResult();

    }

    public IResult DeleteGroup(String IdG)
    {
        var result = _groupDal.Get(e => e.nombre_grupo == IdG);
        if (result != null)
        {
           
            _grupoCursoMateriaDal.Delete(e => e.nombre_grupo == IdG);
            _groupDal.DeleteStudents(IdG);
             _groupDal.Delete(e => e.nombre_grupo == IdG);
            return new SuccessResult();

        }
        return new ErrorResult("Grupo no encontrado");

    }

    public IDataResult<GrupoDTO> Get(String IdG)
    {
        var result = _groupDal.Get(e => e.nombre_grupo == IdG);

        if (result != null)
        {
            var result2 = _grupoCursoMateriaDal.GetAll(e => e.nombre_grupo == IdG);
            List<Materium> materias = new();
            if (result2.Count == 0)
            {
                return new SuccessResultData<GrupoDTO>(new GrupoDTO()
                {
                    NombreGrupo = result.nombre_grupo,
                    Materias = materias,
                    NombreCurso = "No tiene curso"
                });

            }
            else

                foreach (var item in result2)
                {
                    materias.Add(_materiaDal.Get(e => e.NombreMateria == item.nombre_materia));
                }
            var curso = _cursoDal.Get(e => e.IdC == result2.FirstOrDefault().IdC);
            var students = _groupDal.GetStudent(IdG);

            return new SuccessResultData<GrupoDTO>(new GrupoDTO()
            {
                NombreGrupo = result.nombre_grupo,
                Materias = materias,
                NombreCurso = curso.NombreCurso,
                Estudiantes = students
            });
        }
        return new ErrorDataResult<GrupoDTO>();

        }

     public IDataResult<List<GrupoDTO>> GetAll()
        {
            var result = _groupDal.GetAll();
          try
          {
              List<GrupoDTO> grupos = new();
               IDataResult<GrupoDTO> result1;
              
              foreach (var item in result)
              {
                  result1= this.Get(item.nombre_grupo);

              }
              return new SuccessResultData<List<GrupoDTO>>(grupos);
          }
          catch (System.Exception)
          {

            return new ErrorDataResult<List<GrupoDTO>>("error",null);
        //   }
        throw new System.NotImplementedException();

           } }

    public IResult UpdateGroup(String IdG, GrupoDTO gruponew)
    {
        var result = _groupDal.Get(e => e.nombre_grupo == gruponew.NombreGrupo);
        if (result!=null)
        {


            _groupDal.Update(new Grupo()
            {
                nombre_grupo = gruponew.NombreGrupo
            }, e=> e.nombre_grupo == IdG);

            

            return new SuccessResult();

        }
        return new ErrorResult("Grupo no encontrado");
    
    }
}