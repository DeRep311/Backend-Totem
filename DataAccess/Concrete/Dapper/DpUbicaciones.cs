using System.Data;
using System.Linq.Expressions;
using Base.Models;

public class DpUbicacionesDal :  DapperRepositoryBase<Ubicaciones>, IUbicationDal
{
    private ICoordenadasDal _coordenadasDal;
    private ITieneDal _tieneDal;

   public DpUbicacionesDal(IDbConnection connection, ICoordenadasDal coordenadaDal, ITieneDal tieneDal) : base(connection)
    {
        _coordenadasDal = coordenadaDal;
        _tieneDal = tieneDal;
    }

    public virtual void Add(UbicationDTO ubicacione){

        Ubicaciones ubi = new Ubicaciones();

        base.Add(ubi);

        Coordenada coordenada = new Coordenada(){


        };
        _coordenadasDal.Add(coordenada);

        Tiene tiene = new Tiene();
        









    }

    

   
}