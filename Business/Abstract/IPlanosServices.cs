

using Base.Models;

public interface IPlanosServices {
    public IResult Add (PlanosDTO planos);
    public IResult Delete (PlanosDTO planos);
    public IDataResult<List<Plano>> GetAll ();

}

