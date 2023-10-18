using DataAccess.DTOs;
using DataAccess.Models;

public interface IAuthServices {
    

    public IDataResult<UsuarioDTO> Login (int cedula, int pin);


    
}