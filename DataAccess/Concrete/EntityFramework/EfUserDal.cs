using System.Linq.Expressions;
using Core.DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;

public class EfUserDal : EfEntityRepositoryBase<Usuario, DatabaseContext>, IUserDal
{

    public Usuario GetUserRol(Usuario user)
    {

        try
        {
            using DatabaseContext context = new();
            var result = context.Docentes.Any(d => d.Cedula == user.Cedula);
            if (result)
            {
                user.Docente= true;
                return user;
            }
        result = context.Estudiantes.Any(d => d.Cedula == user.Cedula);
    
            if (result)
            {
                user.Estudiante = true;
                return user;
            }
    
    
            return user;
        }
        catch (System.Exception e)
        {
            
            System.Console.WriteLine(e.Message);
            return user;
        }
    }

    public List<Usuario> GetUserRolist(List<Usuario> listuser)
    {

        using DatabaseContext context = new();
        List<Usuario> ListaConType = new ();

        foreach (var user in listuser)
        {
            if (context.Docentes.Any(d => d.Cedula == user.Cedula))
            {
                user.Docente = true;
                ListaConType.Add(user);
            }
            if (context.Estudiantes.Any(d => d.Cedula == user.Cedula))
            {
                user.Docente = true;
                ListaConType.Add(user);
            }

            ListaConType.Add(user);


        }

        return ListaConType;
    }





}