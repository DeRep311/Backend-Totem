using System.Data;
using Base.Models;

public class DpCursoMateria : DapperRepositoryBase<Cm>, ICursoMateria
{
    public DpCursoMateria(IDbConnection connection) : base(connection)
    {
    }
}