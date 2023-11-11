using System.Data;
using Base.Models;

public class DpGrupoCursoMateriaDal : DapperRepositoryBase<GrupoCursoMaterium>, IGrupoCursoMateriaDal
{
    public DpGrupoCursoMateriaDal(IDbConnection connection) : base(connection)
    {
    }
}