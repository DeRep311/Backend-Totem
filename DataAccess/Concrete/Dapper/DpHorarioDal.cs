using System.Data;
using System.Linq.Expressions;
using Base.Models;
using ZstdSharp.Unsafe;

public class DpHorarioDal : DapperRepositoryBase<Horarios>, IHorarioDal
{
    public DpHorarioDal(IDbConnection connection) : base(connection)
    {
    }

}