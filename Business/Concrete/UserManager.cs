using Base.Models;
using DataAccess.DTOs;


public class UserManager : IUserServices
{

    private IUserDal _userDal;
    private IDocenteDal _docenteDal;

    private IEstudianteDal _estudianteDal;
    private IAdministradorDal _administradorDal;

    private IOperadorDal _operadorDal;
    

    public UserManager(IUserDal userDal, IDocenteDal docenteDal, IEstudianteDal estudianteDal, IAdministradorDal administradorDal, IOperadorDal operadorDal)
    {

        _userDal = userDal;
        _docenteDal = docenteDal;
        _estudianteDal = estudianteDal;
        _administradorDal = administradorDal;
        _operadorDal = operadorDal;
    }
  


    public IResult Add(Usuario user)
    {
        _userDal.AddUser(user);
      
      
      

        return new SuccessResult();
    }

    public IResult Delete(int cedula)
    {
        Usuario userDelet = _userDal.Get(cedula);
        if (userDelet == null)
        {
            return new ErrorResult("Usuario no encontradp");
        }
        _userDal.DeleteUser(cedula);
        

        return new SuccessResult();
    }

    public IDataResult<Usuario> Get(int cedula)
    {
        Usuario user = _userDal.Get(cedula);
        if (user == null)
        {
            return new ErrorDataResult<Usuario>("usuario no encontrado", null);
        }
        user= _userDal.GetUserRol(user);
       
        return new SuccessResultData<Usuario>(user);
    }

    public IDataResult<List<Usuario>> GetAll()
    {
        List<Usuario> user = _userDal.GetAll();
        if (user == null)
        {
            
            return new ErrorDataResult<List<Usuario>>("No existen usuarios", null);
        }
        user = _userDal.GetUserRolist(user);

        return new SuccessResultData<List<Usuario>>(user);
    }

    public IResult Update(int cedula, Usuario usernew)
    {
        Usuario userold = _userDal.Get(cedula);
        if (userold == null)
        {
            return new ErrorResult();
        }
        _userDal.UpdateUser(usernew);

        return new SuccessResult();
    }
}

