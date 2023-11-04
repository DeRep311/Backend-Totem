using Base.Models;

public interface IMateriaServices {

    IResult Add (Materium materia);
    IResult Update (String IdM, Materium materianew);

    IDataResult <List<Materium>> GetAll();

    IDataResult <Materium> Get(String IdM);

    IResult Delete(String IdM);
    
}