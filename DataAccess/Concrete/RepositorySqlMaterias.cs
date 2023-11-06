// using System;
// using System.Collections.Generic;
// using Base.Models;
// using DataAccess.DTOs;
// using Microsoft.Data.SqlClient;
// using Microsoft.Extensions.Configuration;
// using MySql.Data.MySqlClient;

// public class SqlMateriaDal : IMateriaDal
// {
//     private readonly MySqlConnection _connection;

//     public SqlMateriaDal(IConfiguration configuration)
//    {
//         string connectionString = "server=localhost;database=apheleontotem;user=root";
//         MySqlConnection connection = new MySqlConnection(connectionString);
//         _connection = connection;
//     }

//     public List<MateriasDTO> Getbygroup(string NombreGrupo)
//     {
//         List<MateriasDTO> materiadocente = new List<MateriasDTO>();

       
//             _connection.Open();

//             // Verifica si el grupo existe
//             using (var checkGroupCmd = new MySqlCommand("SELECT 1 FROM Grupos WHERE NombreGrupo = @NombreGrupo", _connection))
//             {
//                 checkGroupCmd.Parameters.AddWithValue("@NombreGrupo", NombreGrupo);
//                 var groupExists = (int)checkGroupCmd.ExecuteScalar();

//                 if (groupExists == 1)
//                 {
//                     // Obtiene las materias para el grupo
//                     using (var getMateriasCmd = new MySqlCommand("SELECT NombreMateria FROM GrupoCursoMateria WHERE NombreGrupo = @NombreGrupo", _connection))
//                     {
//                         getMateriasCmd.Parameters.AddWithValue("@NombreGrupo", NombreGrupo);

//                         using (var materiasReader = getMateriasCmd.ExecuteReader())
//                         {
//                             while (materiasReader.Read())
//                             {
//                                 string nombreMateria = materiasReader["NombreMateria"].ToString();

//                                 // Consulta la información del docente y horario para cada materia
//                                 using (var getDocenteCmd = new MySqlCommand(
//                                     "SELECT docente.NombreMateria, docente.Cedula, " +
//                                     "infodocente.Nombre AS NombreDocente, infodocente.Apellido AS ApellidoDocente, " +
//                                     "Ubicaciones.CodigoUbicaciones, horarios.* " +
//                                     "FROM Impartes docente " +
//                                     "JOIN Docentes infodocente ON docente.Cedula = infodocente.Cedula " +
//                                     "JOIN HorarioGrupoCursos horario ON docente.NombreMateria = horario.NombreMateria " +
//                                     "JOIN Horarios infohorario ON horario.IdH = infohorario.IdH " +
//                                     "JOIN CursoHorarioUbicacions Ubicaciones ON horario.IdH = Ubicaciones.IdH " +
//                                     "WHERE docente.NombreMateria = @NombreMateria",
//                                     _connection))
//                                 {
//                                     getDocenteCmd.Parameters.AddWithValue("@NombreMateria", nombreMateria);

//                                     using (var docenteReader = getDocenteCmd.ExecuteReader())
//                                     {
//                                         if (docenteReader.Read())
//                                         {
//                                             var materiasDto = new MateriasDTO
//                                             {
//                                                 NombreMateria = docenteReader["NombreMateria"].ToString(),
//                                                 Cedula = (int)docenteReader["Cedula"],
//                                                 NombreDocente = docenteReader["NombreDocente"].ToString(),
//                                                 ApellidoDocente = docenteReader["ApellidoDocente"].ToString(),
//                                                 Ubicacion = docenteReader["CodigoUbicaciones"].ToString(),
//                                                 Horarios = (Horario)docenteReader["Horarios"]
//                                             };

//                                             materiadocente.Add(materiasDto);
//                                         }
//                                     }
//                                 }
//                             }
//                         }
//                     }
//                 }
//             }

//             _connection.Close();
        

//         return materiadocente;
//     }
// }