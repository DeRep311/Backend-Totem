using System.Linq.Expressions;
using Base.Models;
using MySql.Data.MySqlClient;

public class RepositorySqlUbicacion : IUbicationDal
{
    private MySqlConnection _conection;
    public RepositorySqlUbicacion()
    {
        string connectionString = "server=localhost;database=apheleontotem;user=root";
        MySqlConnection connection = new MySqlConnection(connectionString);
        _conection = connection;
    }
    public void Add(Ubicacione entitiy)
    {
        _conection.Open();
        string query = $"INSERT INTO ubicaciones (codigo_ubicaciones, nombre, publico, privado)VALUES ({entitiy.CodigoUbicaciones}, '{entitiy.Nombre}', {entitiy.Publico}, {entitiy.Privado})";
        MySqlCommand cmd = new MySqlCommand(query, _conection);
        cmd.ExecuteNonQuery();
        _conection.Close();    
    }

    public void AddCoo(UbicationDTO ubicacion)
    {
       
    }

    public void AddPlano(UbicationDTO ubication)
    {
        throw new NotImplementedException();
    }

    public void AddRaw(List<Ubicacione> entities)
    {
        throw new NotImplementedException();
    }

    public void Delete(Ubicacione entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteCoo(UbicationDTO ubicacion)
    {
        throw new NotImplementedException();
    }

    public void DeletePlano(UbicationDTO ubication, bool deletePlano)
    {
        throw new NotImplementedException();
    }

    public void DeleteRaw(List<Ubicacione> entities)
    {
        throw new NotImplementedException();
    }

    public Ubicacione Get(Expression<Func<Ubicacione, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<Ubicacione> GetAll(Expression<Func<Ubicacione, bool>>? filter = null)
    {
        throw new NotImplementedException();
    }

    public UbicationDTO GetYourData(Ubicacione ubicacione)
    {
        throw new NotImplementedException();
    }

    public void Update(UbicationDTO ubicacion, UbicationDTO oldUbication)
    {
        throw new NotImplementedException();
    }

    public void Update(Ubicacione newentity, Ubicacione oldentity)
    {
        throw new NotImplementedException();
    }
}