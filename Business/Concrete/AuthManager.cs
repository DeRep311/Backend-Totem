using DataAccess.DTOs;
using DataAccess.Models;

public class AuthManager : IAuthServices
{

    private IUserDal _userDal;
    public AuthManager(IUserDal userDal){
        
        _userDal = userDal;
    }

    public IDataResult<UsuarioDTO> Login(int cedula, int pin)
    {
       var result = _userDal.Get(e => e.Cedula == cedula);
       if (result != null)
       {

              if (result.Pin == pin)
              {
                UsuarioDTO user = new(result);
                
                return new SuccessResultData<UsuarioDTO>(user);
              }
              return new ErrorDataResult<UsuarioDTO>("Pin incorrecto", null);
        
       }
         return new ErrorDataResult<UsuarioDTO>("Usuario no encontrado", null);
    }
}