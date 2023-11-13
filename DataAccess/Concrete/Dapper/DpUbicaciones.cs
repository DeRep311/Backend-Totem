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
            codigo_ubicaciones = ubicacione.CodigoUbicaciones,
            nombre = ubicacione.Nombre,
            publico = ubicacione.Publico,
            privado = ubicacione.Privado
        };
        base.Add(ubi);
        List<Tiene> ids = new ();

        foreach (var item in ubicacione.IdCs)
        {
            Coordenada coor = new Coordenada(){
                coo_x = item.coo_x,
                coo_y = item.coo_y,
                foto = item.foto,
                Inicio = item.Inicio,
                Final = item.Final
            };
            _coordenadasDal.Add(coor);
         ids.Add(new Tiene(){
             id_c = coor.id_c,
             codigo_ubicaciones = ubicacione.CodigoUbicaciones
         });
        }
        _tieneDal.AddRaw(ids);

       
        









    }

    

   
}