using Base.Models;
using Core.DataAccess;


public interface IUbicationDal: IEntityRepository<Ubicacione>

{
     public void AddCoo(UbicationDTO ubicacion);
      public UbicationDTO GetYourData(Ubicacione ubicacione);
      public void Update(UbicationDTO ubicacion, UbicationDTO oldUbication);
      public void AddPlano(UbicationDTO ubication);
        public void DeletePlano(UbicationDTO ubication, bool deletePlano);
         public void DeleteCoo(UbicationDTO ubicacion);
    
}