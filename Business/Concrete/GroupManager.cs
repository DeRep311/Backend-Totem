
using Base.Models;

public class GroupManager : IGroupServices
{

    IGroupDal _groupDal;
    IMateriaDal _materiaDal;
    public GroupManager(IGroupDal groupDal, IMateriaDal materiaDal)
    {
        _groupDal = groupDal;
        _materiaDal = materiaDal;
    }


    
    public IResult CreateGroup(GrupoDTO grupo)
    {
    
        throw new System.NotImplementedException();
            
        }

     
        
    

    public IResult DeleteGroup(String IdG)
    {
        // var result = _groupDal.Get(e => e.NombreGrupo == IdG);
        // if (result!=null)
        // {
        //     _groupDal.Delete(e=> e.NombreGrupo == IdG);
        //     return new SuccessResult();
            
        // }
        // return new ErrorResult("Grupo no encontrado");
        throw new System.NotImplementedException();
    }

    public IDataResult<GrupoDTO> Get(String IdG)
    {
    //    var result= _groupDal.Get(e => e.NombreGrupo == IdG);
    //    var result2 = _materiaDal.Getbygroup(IdG);
    //     if (result!=null)
    //     {
    //         return new SuccessResultData<GrupoDTO>(new GrupoDTO()
    //         {
    //             NombreGrupo = result.NombreGrupo,
    //             Materias = result2,
    //             NombreCurso = result2.FirstOrDefault().CursoNombre
    //         });
    //     }
    //     return new ErrorDataResult<GrupoDTO>();
    throw new System.NotImplementedException();
    }

    public IDataResult<List<GrupoDTO>> GetAll()
    {
    //     var result = _groupDal.GetAll();
    //   try
    //   {
    //       List<GrupoDTO> grupos = new();
    //       foreach (var item in result)
    //       {
    //           grupos.Add(new GrupoDTO()
    //           {
    //               NombreGrupo = item.NombreGrupo,
    //               Materias = _materiaDal.Getbygroup(item.NombreGrupo),
    //               NombreCurso = _materiaDal.Getbygroup(item.NombreGrupo).FirstOrDefault().CursoNombre
    //           });
    //       }
    //       return new SuccessResultData<List<GrupoDTO>>(grupos);
    //   }
    //   catch (System.Exception)
    //   {
        
    //     return new ErrorDataResult<List<GrupoDTO>>();
    //   }
    throw new System.NotImplementedException();
        
    }

    public IResult UpdateGroup(String IdG, GrupoDTO gruponew)
    {
        // var result = _groupDal.Get(e => e.NombreGrupo == gruponew.NombreGrupo);
        // if (result!=null)
        // {
        //     _groupDal.Update(new Grupo()
        //     {
        //         NombreGrupo = gruponew.NombreGrupo
        //     },e=>e.NombreGrupo==IdG);
            
        //     _groupDal.DeleteCourseToGroup(gruponew.NombreGrupo, gruponew.Idc);
        //     _groupDal.AddCourseToGroup(gruponew.NombreGrupo, gruponew.Idc);
        //     _groupDal.DeleteStudentRawToGroup(gruponew.NombreGrupo);
        //     _groupDal.AddStudentToGroup(gruponew.NombreGrupo, gruponew.Estudiantes);

        //     return new SuccessResult();
            
        // }
        // return new ErrorResult("Grupo no encontrado");
        throw new System.NotImplementedException();
    }
}