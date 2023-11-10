using Base.Models;
using Core.entities;

namespace DataAccess.DTOs;




public class UsuarioDTO: IDTO
{


public Usuario User { get; set;}
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes

    public UsuarioDTO(Usuario user){

        User = user;
        user.Pin = 0;

    }


    
}