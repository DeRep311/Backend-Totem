using System.Data;
using Base.Models;

public class DpEstudianteDal : DapperRepositoryBase<Estudiante>, IEstudianteDal
{
    public DpEstudianteDal(IDbConnection connection) : base(connection)
    {
    }
}