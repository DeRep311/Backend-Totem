using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class EfCursosDal :EfEntityRepositoryBase<Curso , DatabaseContext>, ICursoDal
 {
    
}