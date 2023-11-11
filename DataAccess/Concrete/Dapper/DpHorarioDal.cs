using System.Data;
using Base.Models;

public class DpHorarioDal : DapperRepositoryBase<Horario>, IHorarioDal
{
    public DpHorarioDal(IDbConnection connection) : base(connection)
    {
    }
}