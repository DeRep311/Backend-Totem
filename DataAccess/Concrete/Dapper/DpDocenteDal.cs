using System.Data;
using Base.Models;

public class DpDocenteDal : DapperRepositoryBase<Docente>, IDocenteDal
{
    public DpDocenteDal(IDbConnection connection) : base(connection)
    {
    }
}