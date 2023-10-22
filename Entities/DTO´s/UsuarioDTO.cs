using Core.entities;
using DataAccess.Models;
namespace DataAccess.DTOs;
public class UsuarioDTO:IDTO
{
    public UsuarioDTO(Usuario user){
        this.user = user;
        if (user.Operador== true)
        {
            this.IsOperator = true;
        }if (user.Administrador==true)
        {
            this.IsAdmin = true; }
        else {
            this.IsAdmin = false;
            this.IsOperator = false; }


    }

    Usuario user { get; }
    bool IsAdmin { get; }
    bool IsOperator { get; }

    
}