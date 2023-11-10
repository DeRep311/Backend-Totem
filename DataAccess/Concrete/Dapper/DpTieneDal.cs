using System.Data;
using System.Runtime.Intrinsics.Arm;
using Base.Models;

public class DpTieneDal : DapperRepositoryBase<Tiene>, ITieneDal

{

    public DpTieneDal(IDbConnection connection) : base(connection)
    {
    }
}