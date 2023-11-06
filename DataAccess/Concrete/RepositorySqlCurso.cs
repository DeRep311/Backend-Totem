using System.Linq.Expressions;
using Base.Models;
using MySql.Data.MySqlClient;

public class RepositorySqlCursos : ICursoDal
{
    private MySqlConnection _conection;
    public RepositorySqlCursos()
    {
        string connectionString = "server=localhost;database=apheleontotem;user=root";
        MySqlConnection connection = new MySqlConnection(connectionString);
        _conection = connection;
    }
    public void Add(CursoDTO entitiy)
    {
        _conection.Open();
        string query = $"INSERT INTO curso (IdC, NombreCurso) VALUES ({entitiy.IdC}, '{entitiy.NombreCurso}')";
        MySqlCommand cmd = new MySqlCommand(query, _conection);
        cmd.ExecuteNonQuery();
        String query2;
        string query3;
        foreach (var item in entitiy.Materias)
        {
            query2 = $"INSERT INTO materias (NombreMateria) VALUES ('{item.NombreMateria}')";
            MySqlCommand cmd2 = new MySqlCommand(query2, _conection);
            cmd2.ExecuteNonQuery();
            query3 = $"INSERT INTO cm (IdC, NombreMateria) VALUES ({entitiy.IdC}, {item.NombreMateria})";
        }
        cmd.ExecuteNonQuery();

        _conection.Close();
    }

    public void AddRaw(List<Curso> entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(CursoDTO entity)
    {
        _conection.Open();
        string query = $"DELETE FROM curso WHERE IdC = {entity.IdC}";
        MySqlCommand cmd = new MySqlCommand(query, _conection);
        cmd.ExecuteNonQuery();
        _conection.Close();
    }

    public void DeleteRaw(List<Curso> entities)
    {
        throw new NotImplementedException();
    }

    public Curso Get(CursoDTO filter)
    {
        _conection.Open();
        string query = $"SELECT * FROM curso WHERE IdC = {filter.IdC}";
        MySqlCommand cmd = new MySqlCommand(query, _conection);
        MySqlDataReader reader = cmd.ExecuteReader();
        Curso curso = new Curso();
        while (reader.Read())
        {
            curso.IdC = reader.GetInt32(0);
            curso.NombreCurso = reader.GetString(1);
        }
        _conection.Close();
        return curso;
    }


    public List<CursoDTO> GetAll()
    {
        _conection.Open();
        string query = "SELECT * FROM curso";
        MySqlCommand cmd = new MySqlCommand(query, _conection);
        MySqlDataReader reader = cmd.ExecuteReader();
        List<CursoDTO> cursos = new List<CursoDTO>();
        while (reader.Read())
        {
            CursoDTO curso = new CursoDTO();
            curso.IdC = reader.GetInt32(0);
            curso.NombreCurso = reader.GetString(1);

            cursos.Add(curso);
        }
        string query2;
        List<Materium> materias = new List<Materium>();
        foreach (var item in cursos)
        {
            query2 = $"SELECT * FROM cm WHERE IdC = {item.IdC}";

            MySqlCommand cmd2 = new MySqlCommand(query2, _conection);
            MySqlDataReader reader2 = cmd2.ExecuteReader();

            while (reader2.Read())
            {
                Materium materia = new Materium();
                materia.NombreMateria = reader2.GetString(1);
                materias.Add(materia);
            }
            item.Materias = materias;

        }
        _conection.Close();
        return cursos;


    }

    public List<Materium> GetYourMaterias(int IdC)
    {
        throw new NotImplementedException();
    }

    public void Update(Curso newentity, Curso oldentity)
    {
        throw new NotImplementedException();
    }
}