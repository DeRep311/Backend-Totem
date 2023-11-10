using Base.Models;
using DataAccess.DTOs;


public class UserManager : IUserServices
{

<<<<<<< Updated upstream
    private IUserDal _userDal;
  
=======
    private readonly IUserDal _userDal;
>>>>>>> Stashed changes
    

    public UserManager(IUserDal userDal)
    {

        _userDal = userDal;
    
    }
  


    public IResult Add(Usuario user)
    {
<<<<<<< Updated upstream
        _userDal.AddUser(user);
      
      
      

=======
        _userDal.Add(user);
>>>>>>> Stashed changes
        return new SuccessResult();
    }

    public IResult Delete(int cedula)
    {
        Usuario userDelet = _userDal.Get(cedula);
        if (userDelet == null)
        {
            return new ErrorResult("Usuario no encontradp");
        }
<<<<<<< Updated upstream
        _userDal.DeleteUser(cedula);
=======
        _userDal.Delete(e=> e.Cedula == cedula);
>>>>>>> Stashed changes
        

        return new SuccessResult();
    }

    public IDataResult<Usuario> Get(int cedula)
    {
        Usuario user = _userDal.Get(cedula);
        if (user == null)
        {
            return new ErrorDataResult<Usuario>("usuario no encontrado", null);
        }
<<<<<<< Updated upstream
     
=======
        
>>>>>>> Stashed changes
       
        return new SuccessResultData<Usuario>(user);
    }

    public IDataResult<List<Usuario>> GetAll()
    {
        List<Usuario> user = _userDal.GetAll();
        if (user == null)
        {
            
            return new ErrorDataResult<List<Usuario>>("No existen usuarios", null);
        }
<<<<<<< Updated upstream
       
=======
        
>>>>>>> Stashed changes

        return new SuccessResultData<List<Usuario>>(user);
    }

    public IResult Update(int cedula, Usuario usernew)
    {
        Usuario userold = _userDal.Get(cedula);
        if (userold == null)
        {
            return new ErrorResult();
        }
<<<<<<< Updated upstream
        _userDal.UpdateUser(usernew);
=======
        _userDal.Update(usernew, e => e.Cedula == cedula);
>>>>>>> Stashed changes

        return new SuccessResult();
    }
}

