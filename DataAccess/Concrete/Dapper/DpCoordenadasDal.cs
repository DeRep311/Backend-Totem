using System.Data;
using Base.Models;

public class DpCoordenadasDal: DapperRepositoryBase<Coordenada>, ICoordenadasDal
 {
    public DpCoordenadasDal(IDbConnection connection) : base(connection)
    {
    }
    
}