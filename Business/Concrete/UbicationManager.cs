using DataAccess.Models;

public class UbicationManager : IUbicationServices
 {
        private readonly IUbicationDal _UbicationDal;
        private readonly ICoordenadaDal _CordenadasDal;
        
        public UbicationManager(IUbicationDal UbicationDal, ICoordenadaDal coordenadaDal)
        {
            _CordenadasDal= coordenadaDal;
            _UbicationDal = UbicationDal;
        }
        public IResult Add(Ubicacione Ubication, Coordenada coordenada)
        {
            var result =_UbicationDal.Get(e=> e.Codigo == Ubication.Codigo);

            if (result != null)
            {
                _CordenadasDal.Add(coordenada);
                return new SuccessResult();
                
            }

            return new ErrorResult();

            
            
              
        }
        public IResult Delete(string codigo)
        {
            var result = _UbicationDal.Get(e=> e.Codigo == codigo);
            if (result != null)
            {
                _UbicationDal.Delete(result);
                return new SuccessResult();
                
            }
            return new ErrorResult("Ubicacion no encontrada");
            
            
        }
        public IDataResult<List<Ubicacione>> GetAll()
        {
            var result = _UbicationDal.GetAll();
            return new SuccessResultData<List<Ubicacione>>(result);
        }
        public IDataResult<Ubicacione> GetById(string codigo)
        {
            var result = _UbicationDal.Get(u => u.Codigo == codigo);
            return new SuccessResultData<Ubicacione>(result);
        }
        public IResult Update(String Codigo, Ubicacione newUbication)
        {
           var result = _UbicationDal.Get(e=> e.Codigo==Codigo);

           if (result != null)
           {
            _UbicationDal.Update(result, result);
           }
            return new SuccessResult();
        }
    
}