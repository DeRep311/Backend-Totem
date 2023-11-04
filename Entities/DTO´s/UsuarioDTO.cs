using Base.Models;
using Core.entities;

namespace DataAccess.DTOs;




public class UsuarioDTO: IDTO
{


public Usuario User { get; set;}
    public bool IsAdmin { get; set; }
    public bool IsOperator { get; set;}

    public bool IsDocente { get; set;}

    public bool IsEstudiante { get; set;}

    





    public UsuarioDTO(Usuario user){
        user.Pin = 0;
   


    }


    
}