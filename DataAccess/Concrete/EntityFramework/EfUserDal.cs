using System.Linq.Expressions;
using Core.DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;

public class EfUserDal : EfEntityRepositoryBase<Usuario, DatabaseContext>, IUserDal
{

    public Usuario GetUserRol(Usuario user)
    {
        using DatabaseContext context = new();
        if (context.Docentes.Any(d => d.Cedula == user.Cedula))
        {
            user.TypeUser = "Docente";
            return user;
        }
        if (context.Estudiantes.Any(d => d.Cedula == user.Cedula))
        {
            user.TypeUser = "Estudiante";
            return user;
        }

        return user;
    }

    public List<Usuario> GetUserRolist(List<Usuario> listuser)
    {

        using DatabaseContext context = new();
        List<Usuario> ListaConType = new List<Usuario>();

        foreach (var user in listuser)
        {
            if (context.Docentes.Any(d => d.Cedula == user.Cedula))
            {
                user.TypeUser = "Docente";
                ListaConType.Add(user);
            }
            if (context.Estudiantes.Any(d => d.Cedula == user.Cedula))
            {
                user.TypeUser = "Estudiante";
                ListaConType.Add(user);
            }

            ListaConType.Add(user);


        }

        return ListaConType;
    }





}