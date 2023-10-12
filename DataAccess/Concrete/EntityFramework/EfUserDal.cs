using System.Linq.Expressions;
using Core.DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;

public class EfUserDal : EfEntityRepositoryBase<Usuario, DatabaseContext>, IUserDal{

    public Usuario GetUserRol(Expression<Func<Usuario, bool>> filter){
        using DatabaseContext context = new();

       Usuario user = this.Get(filter);
       if (context.Docentes.Any(d=>d.Cedula ==user.Cedula))
       {
        user.TypeUser= "Docente";
        return user;
       }
       if (context.Estudiantes.Any(d=>d.Cedula ==user.Cedula))
       {
            user.TypeUser= "Estudiante";
            return user;
       }
         if (context.Operadors.Any(d=>d.Cedula ==user.Cedula))
       {
            user.TypeUser= "Operador";
            return user;
       }
          if (context.Administradors.Any(d=>d.Cedula ==user.Cedula))
       {
            user.TypeUser= "Administrador";
            return user;
       }
       return user;
    }




}