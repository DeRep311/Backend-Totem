
using Base.Models;
using Microsoft.EntityFrameworkCore;

public class EfUbicacionDal : EfEntityRepositoryBase<Ubicaciones, DatabaseContext>
{
//   public void Update(UbicationDTO ubicacion, UbicationDTO oldUbication){
//         using var context = new DatabaseContext();
//         List<Coordenada> coordenadas = ubicacion.IdCs;
//         context.Ubicaciones.Update(new Ubicacione{
//             CodigoUbicaciones = ubicacion.CodigoUbicaciones,
//             Nombre = ubicacion.Nombre,
//             Publico = ubicacion.Publico,
//             Privado = ubicacion.Privado
//         });
//         context.SaveChanges();
//        List<Tiene> result = context.Tienes.Where(e=> e.CodigoUbicaciones == ubicacion.CodigoUbicaciones).ToList();
//        var coorOld= result.Select(e=> e.IdCNavigation).ToList();
//         context.Tienes.RemoveRange(result);
//         context.Coordenadas.RemoveRange(coorOld);
//         context.SaveChanges();
//         context.Coordenadas.AddRange(coordenadas);
//         context.SaveChanges();
//         foreach(Coordenada coo in coordenadas)
//         {
//             context.Tienes.Add(
//                 new Tiene { 
//                     IdC = coo.IdC, 
//                     CodigoUbicaciones = ubicacion.CodigoUbicaciones
//                      });
        
//         }
//         context.SaveChanges();

//   }
//     public UbicationDTO GetYourData(Ubicacione ubicacione){

//         using var context = new DatabaseContext();
//         List<Coordenada> coordenadas = new List<Coordenada>();
//         var resultcoo = context.Tienes.Where(e=> e.CodigoUbicaciones == ubicacione.CodigoUbicaciones).ToList();
//         var resultplano = context.Ups.Where(e=> e.CodigoUbicaciones == ubicacione.CodigoUbicaciones).FirstOrDefault();
//         foreach (var item in resultcoo)
//         {
           
//             coordenadas.Add(context.Coordenadas.Find(item.IdC));
            
//         }
//         var result = context.Planos.Find(resultplano.CodigoP);
//         return new UbicationDTO{
//             CodigoUbicaciones = ubicacione.CodigoUbicaciones,
//             Nombre = ubicacione.Nombre,
//             Publico = ubicacione.Publico,
//             Privado = ubicacione.Privado,
//             IdCs = coordenadas,
//             CodigoP = resultplano.CodigoP,
//             PlanoImg = result.PlanoImg
//         };
      

        
//     }

  

//     public void AddCoo(UbicationDTO ubicacion)
//     {
//         using var context = new DatabaseContext();
//         List<Coordenada> coordenadas = ubicacion.IdCs;
//         context.Coordenadas.AddRange(coordenadas);
//         context.SaveChanges();
//         foreach(Coordenada coo in coordenadas)
//         {
//             context.Tienes.Add(
//                 new Tiene { 
//                     IdC = coo.IdC, 
//                     CodigoUbicaciones = ubicacion.CodigoUbicaciones
                    
//                      });
        
//         }}

//         public void DeleteCoo(UbicationDTO ubicacion)
//         {
//             using var context = new DatabaseContext();
//             List<Coordenada> coordenadas = ubicacion.IdCs;
//             context.Coordenadas.RemoveRange(coordenadas);
//             context.SaveChanges();
//             context.Tienes.RemoveRange(context.Tienes.Where(t => t.CodigoUbicaciones == ubicacion.CodigoUbicaciones));
//         }

//     public void AddPlano(UbicationDTO ubication){

//         using var context = new DatabaseContext();
//         var result = context.Planos.Find(ubication.CodigoP);
//         if (result ==null)
//         {
//             context.Planos.Add(new Plano{
//                 CodigoP = ubication.CodigoP,
//                 PlanoImg = ubication.PlanoImg
//             });
//             context.SaveChanges();

//         }
//         context.Ups.Add(new Up{
//             CodigoP = ubication.CodigoP,
//             CodigoUbicaciones = ubication.CodigoUbicaciones
//         });
//         context.SaveChanges();
//     }

//     public void DeletePlano(UbicationDTO ubication, bool deletePlano)
//     {
//       using var context = new DatabaseContext();
//         if (deletePlano)
//         {
//             var resultplano= context.Planos.Find(ubication.CodigoP);
//             if (resultplano != null)
//             {
//                 context.Planos.Remove(resultplano);
//                 context.SaveChanges();
//             }
//         }
//             context.Ups.RemoveRange(context.Ups.Where(u => u.CodigoUbicaciones == ubication.CodigoUbicaciones));
//             context.SaveChanges();
        

//     }
    
    
}