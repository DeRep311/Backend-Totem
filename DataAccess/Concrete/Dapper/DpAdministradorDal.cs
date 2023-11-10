using System.Data;
using Base.Models;

public class DpAdministradorDal : DapperRepositoryBase<Administrador>, IAdministradorDal
{
    public DpAdministradorDal(IDbConnection connection) : base(connection)
    {
    }
}