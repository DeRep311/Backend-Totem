using Base.Models;
using DataAccess.DTOs;


public class UserManager : IUserServices
{

    private IUserDal _userDal;
  
    

    public UserManager(IUserDal userDal)
    {

        _userDal = userDal;
    
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

