

using DataAccess.Models;

public interface IUserServices
{

    IResult Add(Usuario user);
    IResult Update(int cedula, Usuario usernew);

    IDataResult<List<Usuario>> GetAll();

    IDataResult<Usuario> Get(int cedula);

    IResult Delete(int cedula);



}