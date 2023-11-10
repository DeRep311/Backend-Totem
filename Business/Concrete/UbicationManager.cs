using Base.Models;


public class UbicationManager : IUbicationServices
 {
        private readonly IUbicationDal _UbicationDal;
        
        public UbicationManager(IUbicationDal UbicationDal)
        {
            _UbicationDal = UbicationDal;
        }
        public IResult Add(UbicationDTO Ubicationdto)
        {
         throw new System.NotImplementedException();
         
        }
        public IResult Delete(UbicationDTO ubication)
        {
           throw new System.NotImplementedException();
            
        }
        public IDataResult<List<UbicationDTO>> GetAll()
        {
           throw new System.NotImplementedException();
        }
 
        public IResult Update(UbicationDTO ubicacionnew)
        {
           throw new System.NotImplementedException();
           
        }
    
}