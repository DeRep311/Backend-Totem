using DataAccess.Models;

public interface IMateriaServices {

    IResult Add (Materium materia);
    IResult Update (int IdM, Materium materianew);

    IDataResult <List<Materium>> GetAll();

    IDataResult <Materium> Get(int IdM);

    IResult Delete(int IdM);
    
}