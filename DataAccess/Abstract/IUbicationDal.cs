using Base.Models;
using Core.DataAccess;


public interface IUbicationDal : IEntityRepository<Ubicaciones>

{
     public void AddC(UbicationDTO ubicacione);

}