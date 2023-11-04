using Base.Models;
using Core.DataAccess;


public interface ICursoDal: IEntityRepository<Curso>
 {
    public List<Materium> GetYourMaterias(int IdC);
    
}