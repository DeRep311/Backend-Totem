using Base.Models;
using Core.DataAccess;


public interface ICursoDal
 {

   
    public List<CursoDTO> GetAll();
    public Curso Get(CursoDTO curso);
    public void Add(CursoDTO curso);
    public void Delete(CursoDTO entity);

    
}