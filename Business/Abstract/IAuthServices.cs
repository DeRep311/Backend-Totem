using Core.entities;
using DataAccess.DTOs;
using DataAccess.Models;

public interface IAuthServices {


    public IDataResult<UsuarioDTO> Login(IDTO datos);


    
}