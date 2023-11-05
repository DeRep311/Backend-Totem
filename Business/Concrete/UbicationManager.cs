using Base.Models;


public class UbicationManager : IUbicationServices
 {
        private readonly IUbicationDal _UbicationDal;
        
        public UbicationManager(IUbicationDal UbicationDal)
        {
            _UbicationDal = UbicationDal;
        }
        public IResult Add(UbicationDTO Ubication)
        {
            var result =_UbicationDal.Get(e=> e.CodigoUbicaciones == Ubication.CodigoUbicaciones);

            if (result == null)
            {

               _UbicationDal.Add(new Ubicacione{
                     CodigoUbicaciones = Ubication.CodigoUbicaciones,
                     Nombre = Ubication.Nombre,
                     Publico = Ubication.Publico,
                     Privado = Ubication.Privado
               });
               _UbicationDal.AddCoo(Ubication);

               _UbicationDal.AddPlano(Ubication);
               
                return new SuccessResult();
                
            }

            return new ErrorResult();

            
            
              
        }
        public IResult Delete(UbicationDTO ubication)
        {
            var result = _UbicationDal.Get(e=> e.CodigoUbicaciones == ubication.CodigoUbicaciones);
            if (result != null)
            {
                _UbicationDal.Delete(result);
                _UbicationDal.DeleteCoo(ubication);
                _UbicationDal.DeletePlano(ubication, false);
                return new SuccessResult();
                
            }
            return new ErrorResult("Ubicacion no encontrada");
            
            
        }
        public IDataResult<List<UbicationDTO>> GetAll()
        {
            var result = _UbicationDal.GetAll();
            List<UbicationDTO> ubicaciones = new();
            foreach (var item in result)
            {
                  var result2 = _UbicationDal.GetYourData(item);
                    ubicaciones.Add(result2);
            }
          
            return new SuccessResultData<List<UbicationDTO>>(ubicaciones);
        }
 
        public IResult Update(UbicationDTO ubicacionnew)
        {
           var result = _UbicationDal.Get(e=> e.CodigoUbicaciones==ubicacionnew.CodigoUbicaciones);
           UbicationDTO old = _UbicationDal.GetYourData(result);

           if (result != null)
           {
            _UbicationDal.Update(ubicacionnew, old);
             return new SuccessResult();
           }
              return new ErrorResult("Ubicacion no encontrada");
           
        }
    
}