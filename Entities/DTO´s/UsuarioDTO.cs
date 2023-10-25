using Core.entities;
using DataAccess.Models;
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
        this.User = user;
        if (user.Operador== true)
        {
            this.IsOperator = true;
        }if (user.Administrador==true)
        {
            this.IsAdmin = true; }
        else {
            this.IsAdmin = false;
            this.IsOperator = false; }
        if (user.Docente==true){
            this.IsDocente = true;
        }
        else{
            this.IsDocente = false;
        }
        if (user.Estudiante==true){
            this.IsEstudiante = true;
        }
        else{
            this.IsEstudiante = false;
        }


    }


    
}