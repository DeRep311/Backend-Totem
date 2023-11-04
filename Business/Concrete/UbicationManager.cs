using Base.Models;


public class UbicationManager : IUbicationServices
 {
        private readonly IUbicationDal _UbicationDal;
        
        public UbicationManager(IUbicationDal UbicationDal)
        {
            _UbicationDal = UbicationDal;
        }
        public IResult Add(Ubicacione Ubication)
        {
            var result =_UbicationDal.Get(e=> e.CodigoUbicaciones == Ubication.CodigoUbicaciones);

            if (result == null)
            {

               _UbicationDal.Add(Ubication);
               
                return new SuccessResult();
                
            }

            return new ErrorResult();

            
            
              
        }
        public IResult Delete(string codigo)
        {
            var result = _UbicationDal.Get(e=> e.CodigoUbicaciones == codigo);
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
            var result = _UbicationDal.Get(u => u.CodigoUbicaciones == codigo);
            return new SuccessResultData<Ubicacione>(result);
        }
        public IResult Update(String Codigo, Ubicacione newUbication)
        {
           var result = _UbicationDal.Get(e=> e.CodigoUbicaciones==Codigo);

           if (result != null)
           {
            _UbicationDal.Update(newUbication, result);
           }
            return new SuccessResult();
        }
    
}