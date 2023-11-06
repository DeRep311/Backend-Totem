using Base.Models;
using Core.DataAccess;
using DataAccess.DTOs;


public interface IUserDal 
{


  public Usuario Get (int cedula);

  public List<Usuario> GetAll ();

  public void AddUser (Usuario user);

  public void UpdateUser (Usuario user);

  public void DeleteUser (int cedula);


}