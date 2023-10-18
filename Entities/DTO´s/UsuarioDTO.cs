using Core.entities;
using DataAccess.Models;
namespace DataAccess.DTOs;
public class UsuarioDTO:IDTO
{
    public UsuarioDTO(Usuario user){
        this.user = user;
        if (user.Operador== 1)
        {
            this.IsOperator = true;
        }if (user.Administrador== 1)
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