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
        var result = _cursoMateriaDal.GetAll(e => e.id_c== IdC);
        List<Materium> materias= new();
        foreach (var item in result)
        {
            if (item.nombre_materia == null)
            {
                 materias.Add(new Materium(){
                nombre_materia= item.nombre_materia,
            });
                
            }
        }

        return materias;
    }
}