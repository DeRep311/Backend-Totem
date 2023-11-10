using System.Data;
using Base.Models;

public class DpOperadorDal : DapperRepositoryBase<Operador>, IOperadorDal
{
    public DpOperadorDal(IDbConnection connection) : base(connection)
    {
    }
}