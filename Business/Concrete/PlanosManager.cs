using Base.Models;

public class PlanosManager: IPlanosServices {
    private IPlanosDal _planosDal;
    public PlanosManager (IPlanosDal planosDal) {
        _planosDal = planosDal;
    }
    public IResult Add (PlanosDTO planos) {
        var result= _planosDal.Get (p => p.codigo_p == planos.Plano.codigo_p);
        if (result != null) {
            return new ErrorResult ("Ya existe un plano con ese codigo");
        } else {
            _planosDal.Add (planos.Plano);
            return new SuccessResult ();
        }
        {
            
        }
    }
    public IResult Delete (PlanosDTO planos) {
        var result = _planosDal.Get (p => p.codigo_p == planos.Plano.codigo_p);
        if (result != null) {
            _planosDal.Delete (p => p.codigo_p == planos.Plano.codigo_p);
            return new SuccessResult ();
        } else {
            return new ErrorResult ("No existe un plano con ese codigo");
        }
    }
    public IDataResult<List<Plano>> GetAll () {

        var result = _planosDal.GetAll ();
        return new SuccessResultData<List<Plano>>(result);
    }
   

}