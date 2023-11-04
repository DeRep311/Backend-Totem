using Core.entities;
using DataAccess.DTOs;


public interface IAuthServices {


    public IDataResult<UsuarioDTO> Login(IDTO datos);


    
}