using System.Data;
using Base.Models;

public class DpGrupoDal : DapperRepositoryBase<Grupo>, IGroupDal
{
    private IEstudia_en _estudia_En;    
    private IEstudianteDal _estudianteDal;
    public DpGrupoDal(IDbConnection connection, IEstudia_en estudia_En, IEstudianteDal estudianteDal) : base(connection)
    {
       _estudia_En = estudia_En;
         _estudianteDal = estudianteDal;
    }
    public IResult DeleteStudents(String IdG){
       List<EstudiaEn> result = _estudia_En.GetAll(x => x.nombre_grupo == IdG);
        if (result == null)
        {
            return new ErrorResult("No hay estudiantes en este grupo");
        }
        else
        {
            foreach (var item in result)
            {
                _estudia_En.Delete(e=> e.nombre_grupo==item.nombre_grupo);
            }
            return new SuccessResult("Estudiantes eliminados");
        }
    }

    public List<Estudiante> GetStudent(String grupo)
    {
        var result = _estudia_En.GetAll(x => x.nombre_grupo == grupo);
          List<Estudiante> student= new();

        if(result == null)
        {
            return student;
        }
        else
        {
          
           foreach (var item in result)
           {
            student.Add(new Estudiante(){
                Cedula= item.Cedula,
            });
        
           }
              return student;   
        }


    }

    public IResult AddStudents(String grupo, List<Estudiante> estudiantes)
    {
        foreach (var item in estudiantes)
        {
            _estudianteDal.Get(e=> e.Cedula == item.Cedula);
            if(item == null)
            {
                return new ErrorResult($"Estudiante no encontrado {item.Cedula}");
            }
            
            _estudia_En.Add(new EstudiaEn(){
                Cedula= item.Cedula,
                nombre_grupo= grupo
            });
        }
        return new SuccessResult("Estudiantes agregados");
    }
}