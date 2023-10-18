using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class EfCursoMateriaDal : EfEntityRepositoryBase<Materium, DatabaseContext>{


//  public List<MateriasCursoDTO> MateriasEstudiante(int Cedula){

//         using DatabaseContext context = new();

//         var result = from curso in context.Cursos.Where(e=>e.Cedula==Cedula)
//                         join CM in context.Cms on curso.IdC equals CM.IdC 
//                         join materia in context.Materia on CM.IdM equals materia.IdM
//                         join UCU in context.HorarioCmUbicaciones on CM.IdM equals UCU.IdM
//                         join Ubi in context.Ubicaciones on UCU.Codigo equals Ubi.Codigo
//                         join horary in context.Horarios on UCU.IdH equals horary.IdH
                         
//                         select new MateriasCursoDTO{
                            
//                             CursoNombre= curso.Nombre,
//                             NombreMateria = materia.Nombre,
//                             CedulaProfesor = materia.Cedula,
//                             Ubicacion = Ubi.Nombre,
//                             Hinicio= horary.HoraInicio,
//                             Hfinal = horary.HoraFinal


//                         };





//        return result.ToList();
//     }
//     public List<MateriasCursoDTO> MateriasDocente(int Cedula){

//         using DatabaseContext context = new();

//         var result = from materia in context.Materia.Where(e => e.Cedula == Cedula)
//                         join CM in context.Cms on materia.IdM equals CM.IdM
//                         join curso in context.Cursos on CM.IdC equals curso.IdC
//                         join UCU in context.HorarioCmUbicaciones on materia.IdM equals UCU.IdM
//                         join Ubi in context.Ubicaciones on UCU.Codigo equals Ubi.Codigo
//                         join horary in context.Horarios on UCU.IdH equals horary.IdH
                         
//                         select new MateriasCursoDTO{
                            
//                             CursoNombre= curso.Nombre,
//                             NombreMateria = materia.Nombre,
//                             CedulaProfesor = materia.Cedula,
//                             Ubicacion = Ubi.Nombre,
//                             Hinicio= horary.HoraInicio,
//                             Hfinal = horary.HoraFinal


//                         };





//        return result.ToList();
//     }


}