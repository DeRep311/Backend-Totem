// using System.Linq.Expressions;
// using Base.Models;
// using Core.DataAccess;

// using Microsoft.EntityFrameworkCore.Storage;
// using Microsoft.Identity.Client;

// public class EfUserDal : EfEntityRepositoryBase<Usuario, DatabaseContext>
// {

//     public Usuario GetUserRol(Usuario user)
//     {

//         try
//         {
//             using DatabaseContext context = new();
//             var result = context.Docentes.Any(d => d.Cedula == user.Cedula);
//             if (result)
//             {
//                 user.Rol = "Docente";
//                 return user;
//             }
//             result = context.Estudiantes.Any(d => d.Cedula == user.Cedula);

//             if (result)
//             {
//                 user.Rol = "Estudiante";
//                 return user;
//             }
//             result = context.Administradors.Any(d => d.Cedula == user.Cedula);
//             if (result)
//             {
//                 user.Rol = "Administrador";
//                 return user;
//             }
//             result = context.Operadors.Any(d => d.Cedula == user.Cedula);
//             if (result)
//             {
//                 user.Rol = "Operador";
//                 return user;
//             }
//             return user;
//         }
//         catch (System.Exception e)
//         {

//             System.Console.WriteLine(e.Message);
//             return user;
//         }
//     }

//     public List<Usuario> GetUserRolist(List<Usuario> listuser)
//     {

//         using DatabaseContext context = new();
//         List<Usuario> ListaConType = new();

//         foreach (var user in listuser)
//         {
//            this.GetUserRol(user);

//             ListaConType.Add(user);


//         }

//         return ListaConType;
//     }

  




// }