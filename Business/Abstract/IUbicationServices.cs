using Base.Models;


public interface IUbicationServices {
    
    public IResult Add(Ubicacione Ubication);
    public IResult Delete(string codigo);

    public IDataResult<List<Ubicacione>> GetAll();

    public IDataResult<Ubicacione> GetById(string codigo);

    public IResult Update(String Codigo, Ubicacione newUbication);

    
    


}