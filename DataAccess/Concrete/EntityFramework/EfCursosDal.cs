using Base.Models;

using Microsoft.EntityFrameworkCore;

public class EfCursosDal : EfEntityRepositoryBase<Curso, DatabaseContext>, ICursoDal
{
    public List<Materium> GetYourMaterias(int IdC)
    {
        using DatabaseContext context = new();
        if (context.Cms.Any(e => e.id_c == IdC))
        {
             List<Cm> result = context.Cms.Where(e => e.id_c == IdC).ToList();
        List<Materium> materias = new();
        foreach (var item in result)
        {
        
  
        }
        return materias;
            
        }
        else
        {
            return null;
        }
      
    }
}