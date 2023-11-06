using Base.Models;
using MySql.Data.MySqlClient;

public class RepositorySqlRelations 
{
    private MySqlConnection _conection;
    public RepositorySqlRelations()
    {
        string connectionString = "server=localhost;database=apheleontotem;user=root";
        MySqlConnection connection = new MySqlConnection(connectionString);
        _conection = connection;
    }

public void addCm(int IdC, string NombreMateria){
    _conection.Open();
    string query = $"INSERT INTO cm (IdC, NombreMateria) VALUES ({IdC}, {NombreMateria})";
    MySqlCommand cmd = new MySqlCommand(query, _conection);
    cmd.ExecuteNonQuery();
    _conection.Close();
}

public void AddGrupoCursoMateria (GrupoCursoMaterium grupoCursoMaterium){
    _conection.Open();
    string query = $"INSERT INTO grupo_curso_materia (nombre_grupo, nombre_materia, id_c) VALUES ( {grupoCursoMaterium.NombreGrupo}, {grupoCursoMaterium.NombreMateria},{grupoCursoMaterium.IdC})";
  
    MySqlCommand cmd = new MySqlCommand(query, _conection);
    cmd.ExecuteNonQuery();
    _conection.Close();
}

public void AddGrupoEstudiante (EstudiaEn grupoEstudiante){
    _conection.Open();
    string query = $"INSERT INTO estudia_en (cedula, nombre_grupo) VALUES ( {grupoEstudiante.Cedula}, {grupoEstudiante.NombreGrupo})";
  
    MySqlCommand cmd = new MySqlCommand(query, _conection);
    cmd.ExecuteNonQuery();
    _conection.Close();
}

public void removeCursoGrupoMateria (int IdC, string NombreMateria){
    _conection.Open();
    string query = $"DELETE FROM cm WHERE IdC = {IdC} AND NombreMateria = {NombreMateria}";
    MySqlCommand cmd = new MySqlCommand(query, _conection);
    cmd.ExecuteNonQuery();
    _conection.Close();
}

public void removeEstudianteGrupo (int cedula, string NombreGrupo){
    _conection.Open();
    string query = $"DELETE FROM estudia_en WHERE cedula = {cedula} AND nombre_grupo = {NombreGrupo}";
    MySqlCommand cmd = new MySqlCommand(query, _conection);
    cmd.ExecuteNonQuery();
    _conection.Close();
}


}
