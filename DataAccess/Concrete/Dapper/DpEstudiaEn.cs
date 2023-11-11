using System.Data;
using Base.Models;

public class DpEstudiaEn : DapperRepositoryBase<EstudiaEn>, IEstudia_en
{
    public DpEstudiaEn(IDbConnection connection) : base(connection)
    {
    }
}