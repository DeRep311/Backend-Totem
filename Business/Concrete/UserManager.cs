using Base.Models;


public class UserManager : IUserServices
{

    private readonly IUserDal _userDal;
    

    public UserManager(IUserDal userDal)
    {

        _userDal = userDal;
    
    }
  


    public IResult Add(Usuario user)
    {
        _userDal.Add(user);
        return new SuccessResult();
    }

    public IResult Delete(int cedula)
    {
        Usuario userDelet = _userDal.Get(e => e.Cedula == cedula);
        if (userDelet == null)
        {
            return new ErrorResult("Usuario no encontradp");
        }
        _userDal.Delete(e=> e.Cedula == cedula);
        

        return new SuccessResult();
    }

    public IDataResult<Usuario> Get(int cedula)
    {
        Usuario user = _userDal.Get(e => e.Cedula == cedula);
        if (user == null)
        {
            return new ErrorDataResult<Usuario>("usuario no encontrado", null);
        }
        
       
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
        Usuario userold = _userDal.Get(e => e.Cedula == cedula);
        if (userold == null)
        {
            return new ErrorResult();
        }
        _userDal.Update(usernew, e => e.Cedula == cedula);

        return new SuccessResult();
    }
}

