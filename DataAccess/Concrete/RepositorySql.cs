using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Base.Models;
using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;



public class RepositorySql : IUserDal
{
    private MySqlConnection _conection;
    public RepositorySql()
    {
        string connectionString = "server=localhost;database=apheleontotem;user=root";
        MySqlConnection connection = new MySqlConnection(connectionString);
        _conection = connection;
    }


    public void AddUser(Usuario user)
    {
        try
        {
            _conection.Open();
           
            String query = $"INSERT INTO usuario (Cedula, Nombre, Apellido, Telefono, Direccion, Pin) VALUES ({user.Cedula}, '{user.Nombre}', '{user.Apellido}', {user.Telefono}, {user.Direccion}, {user.Pin})";
            MySqlCommand cmd = new MySqlCommand(query, _conection);
    
            System.Console.WriteLine(cmd.CommandText);
            cmd.ExecuteNonQuery();

            switch (user.Rol)
            {
                case "Administrador":
                    cmd = new MySqlCommand("INSERT INTO administrador (Cedula) VALUES (@Cedula)", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);
                    break;
                case "Docente":
                    cmd = new MySqlCommand("INSERT INTO docente (Cedula) VALUES (@Cedula)", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);
                    break;
                case "Estudiante":
                    cmd = new MySqlCommand("INSERT INTO estudiante (Cedula) VALUES (@Cedula)", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);
                    break;
                case "Operador":
                    cmd = new MySqlCommand("INSERT INTO operador (Cedula) VALUES (@Cedula)", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);
                    break;
                default:
                    break;
            }
            cmd.ExecuteNonQuery();


            _conection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void DeleteUser(int cedula)
    {
        try
        {
            _conection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM usuario WHERE Cedula = @Cedula", _conection);
            var result = this.Get(cedula);
            cmd.Parameters.AddWithValue("@Cedula", cedula);
            switch (result.Rol)
            {

                case "Administrador":
                    cmd = new MySqlCommand("DELETE FROM administrador WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    break;
                case "Docente":
                    cmd = new MySqlCommand("DELETE FROM docente WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    break;
                case "Estudiante":
                    cmd = new MySqlCommand("DELETE FROM estudiante WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    break;
                case "Operador":
                    cmd = new MySqlCommand("DELETE FROM operador WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", cedula);

                    break;
                default:
                    break;
            }
            cmd.ExecuteNonQuery();
            _conection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void UpdateUser(Usuario user)
    {
        try
        {
            _conection.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE usuario SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Direccion = @Direccion, Pin = @Pin WHERE Cedula = @Cedula", _conection);
            cmd.Parameters.AddWithValue("@Cedula", user.Cedula);
            cmd.Parameters.AddWithValue("@Nombre", user.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", user.Apellido);
            cmd.Parameters.AddWithValue("@Telefono", user.Telefono);
            cmd.Parameters.AddWithValue("@Direccion", user.Direccion);
            cmd.Parameters.AddWithValue("@Pin", user.Pin);
            switch (user.Rol)
            {

                case "Administrador":
                    cmd = new MySqlCommand("UPDATE administrador SET Cedula = @Cedula WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);

                    break;
                case "Docente":
                    cmd = new MySqlCommand("UPDATE docente SET Cedula = @Cedula WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);

                    break;
                case "Estudiante":
                    cmd = new MySqlCommand("UPDATE estudiante SET Cedula = @Cedula WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);

                    break;
                case "Operador":
                    cmd = new MySqlCommand("UPDATE operador SET Cedula = @Cedula WHERE Cedula = @Cedula", _conection);
                    cmd.Parameters.AddWithValue("@Cedula", user.Cedula);

                    break;
                default:
                    break;
            }
            cmd.ExecuteNonQuery();
            _conection.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public Usuario Get(int cedula)
    {
        try
        {
            _conection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE Cedula = @Cedula", _conection);
            cmd.Parameters.AddWithValue("@Cedula", cedula);
            MySqlDataReader reader = cmd.ExecuteReader();
            Usuario user2 = new Usuario();
            while (reader.Read())
            {
                user2.Cedula = reader.GetInt32(0);
                user2.Nombre = reader.GetString(1);
                user2.Apellido = reader.GetString(2);
                user2.Telefono = reader.GetInt32(3);
                user2.Direccion = reader.GetInt32(4);
                user2.Pin = reader.GetInt32(5);
            }
            _conection.Close();
            return user2;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    public List<Usuario> GetAll()
    {
    try
{
    List<Usuario> users = new List<Usuario>();

  
        _conection.Open();
        using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario", _conection))
        {
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Usuario user = new Usuario();
                    user.Cedula = reader.GetInt32(0);
                    user.Nombre = reader.GetString(1);
                    user.Apellido = reader.GetString(2);
                    user.Telefono = reader.GetInt32(3);
                    user.Direccion = reader.GetInt32(4);
                    user.Pin = reader.GetInt32(5);
                    users.Add(user);
                }
            }
        }

        foreach (var user in users)
        {
            using (MySqlCommand cmdDocente = new MySqlCommand("SELECT COUNT(*) FROM docente WHERE cedula=@Cedula", _conection))
            using (MySqlCommand cmdEstudiante = new MySqlCommand("SELECT COUNT(*) FROM estudiante WHERE cedula=@Cedula", _conection))
            using (MySqlCommand cmdOperador = new MySqlCommand("SELECT COUNT(*) FROM operador WHERE cedula=@Cedula", _conection))
            using (MySqlCommand cmdAdministrador = new MySqlCommand("SELECT COUNT(*) FROM administrador WHERE cedula=@Cedula", _conection))
            {
                cmdDocente.Parameters.AddWithValue("@Cedula", user.Cedula);
                cmdEstudiante.Parameters.AddWithValue("@Cedula", user.Cedula);
                cmdOperador.Parameters.AddWithValue("@Cedula", user.Cedula);
                cmdAdministrador.Parameters.AddWithValue("@Cedula", user.Cedula);

                int countDocente = Convert.ToInt32(cmdDocente.ExecuteScalar());
                int countEstudiante = Convert.ToInt32(cmdEstudiante.ExecuteScalar());
                int countOperador = Convert.ToInt32(cmdOperador.ExecuteScalar());
                int countAdministrador = Convert.ToInt32(cmdAdministrador.ExecuteScalar());

                if (countDocente != 0)
                {
                    user.Rol = "Docente";
                }
                else if (countEstudiante != 0)
                {
                    user.Rol = "Estudiante";
                }
                else if (countOperador != 0)
                {
                    user.Rol = "Operador";
                }
                else if (countAdministrador != 0)
                {
                    user.Rol = "Administrador";
                }
            }
        }
    

    return users;
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    // Manejar la excepción según tus necesidades
    return new List<Usuario>();
}

            
    }
    
  

    public Usuario GetUserRol(Usuario user)
    {
        throw new NotImplementedException();
    }

    public List<Usuario> GetUserRolist(List<Usuario> listuser)
    {
        throw new NotImplementedException();
    }






}



