using System.Data;
using Base.Models;

public class DpMateriasDal : DapperRepositoryBase<Materium>, IMateriaDal
{
    public DpMateriasDal(IDbConnection connection) : base(connection)
    {
    }

    
}