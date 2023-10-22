using System.Reflection.Metadata.Ecma335;
using Core.entities;
using DataAccess.DTOs;
using DataAccess.Models;

public class AuthManager : IAuthServices
{

  private IUserDal _userDal;
  public AuthManager(IUserDal userDal)
  {

    _userDal = userDal;
  }

  public IDataResult<UsuarioDTO> Login(IDTO dato)
  {

    if (dato is AuthDTO datos)
    {
      var result = _userDal.Get(e => e.Cedula == datos.cedula);
    if (result != null)
    {

      if (result.Pin == datos.pin)
      {
        UsuarioDTO user = new(result);

        return new SuccessResultData<UsuarioDTO>(user);
      }
      return new ErrorDataResult<UsuarioDTO>("Pin incorrecto", null);

    }
    return new ErrorDataResult<UsuarioDTO>("Usuario no encontrado", null);
  }
     return new ErrorDataResult<UsuarioDTO>("Datos incorrectos", null);
      
    }

   
    
}