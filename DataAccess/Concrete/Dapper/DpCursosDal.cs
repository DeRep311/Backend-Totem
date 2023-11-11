using System.Data;
using Base.Models;

public class DpCursosDal : DapperRepositoryBase<Curso>, ICursoDal
{
    ICursoMateria _cursoMateriaDal;
    public DpCursosDal(IDbConnection connection, ICursoMateria cursoMateria) : base(connection)
    {
        _cursoMateriaDal = cursoMateria;
    }

    public List<Materium> GetYourMaterias(int IdC)
    {
        var result = _cursoMateriaDal.GetAll(e => e.IdC== IdC);
        List<Materium> materias= new();
        foreach (var item in result)
        {
            if (item.NombreMateria == null)
            {
                 materias.Add(new Materium(){
                NombreMateria= item.NombreMateria,
            });
                
            }
        }

        return materias;
    }
}