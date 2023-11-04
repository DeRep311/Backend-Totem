using Base.Models;
using Core.DataAccess;


public interface IUserDal : IEntityRepository<Usuario>
{
  public Usuario GetUserRol(Usuario user);
  public List<Usuario> GetUserRolist (List<Usuario> listuser);
}