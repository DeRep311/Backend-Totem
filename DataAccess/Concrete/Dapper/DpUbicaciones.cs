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

    public virtual void AddC(UbicationDTO ubicacione){

        Ubicaciones ubi = new Ubicaciones(){
            CodigoUbicaciones = ubicacione.CodigoUbicaciones,
            Nombre = ubicacione.Nombre,
            Publico = ubicacione.Publico,
            Privado = ubicacione.Privado
        };
        base.Add(ubi);

        foreach (var item in ubicacione.IdCs)
        {
            Coordenada coor = new Coordenada(){
                CooX = item.CooX,
                CooY = item.CooY,
                Foto = item.Foto,
                Inicio = item.Inicio,
                Final = item.Final
            };
            _coordenadasDal.Add(coor);
        }

        Tiene tiene = new Tiene();
        









    }

    

   
}