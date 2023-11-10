using System.Data;
using System.Linq.Expressions;
using Base.Models;

public class DpUserDal : DapperRepositoryBase<Usuario>, IUserDal
{
    private IAdministradorDal _administradorDal;
    private IDocenteDal _docenteDal;
    private IEstudianteDal _estudianteDal;
    private IOperadorDal _operadorDal;

    public DpUserDal(IDbConnection connection, IAdministradorDal administradorDal, IDocenteDal docenteDal, IEstudianteDal estudianteDal, IOperadorDal operadorDal) : base(connection)
    {
        _administradorDal = administradorDal;
        _docenteDal = docenteDal;
        _estudianteDal = estudianteDal;
        _operadorDal = operadorDal;
    }

    public virtual void Add (Usuario user){
        base.Add(user);
          
          switch (user.Rol)
        {
            case "Docente":
                Docente docente = new()
                {
                    Cedula = user.Cedula
                };
                _docenteDal.Add(docente);
                break;
            case "Estudiante":
                Estudiante estudiante = new(){
                    Cedula = user.Cedula
                };
                _estudianteDal.Add(estudiante);
                break;
            
            case "Administrador":
                Administrador administrador = new(){
                    Cedula = user.Cedula
                };
                _administradorDal.Add(administrador);
                break;

            case "Operador":
                Operador operador = new(){
                    Cedula = user.Cedula
                };
                _operadorDal.Add(operador);
                break;
        }
    }



   public virtual List<Usuario> GetAll(Expression<Func<Usuario, bool>>? filter = null)
{
    List<Usuario> users = base.GetAll(filter);
    if (users == null)
    {
        return null;
    }else
    foreach (var user in users)
    {  
        
        if (_administradorDal.Get((e) => e.Cedula == user.Cedula) != null){
            user.Rol = "Administrador";
        }
        else if (_docenteDal.Get((e) => e.Cedula == user.Cedula) != null)
        {
            user.Rol = "Docente";
        }
        else if (_estudianteDal.Get((e) => e.Cedula == user.Cedula) != null)
        {
            user.Rol = "Estudiante";
        }
        else if (_operadorDal.Get((e) => e.Cedula == user.Cedula) != null)
        {
            user.Rol = "Operador";
        }
    }

    return users;
}

    public virtual Usuario Get(Expression<Func<Usuario, bool>> filter){

        var user = base.Get(filter);
        if (user == null)
        {
            return null;
        }
        else
        if (_administradorDal.Get(e=> e.Cedula== user.Cedula)!= null)
           {
            user.Rol = "Administrador";
           }
              else if (_docenteDal.Get(e=> e.Cedula== user.Cedula)!= null)
              {
                user.Rol = "Docente";
              }
              else if (_estudianteDal.Get(e=> e.Cedula== user.Cedula)!= null)
              {
                user.Rol = "Estudiante";
              }
              else if (_operadorDal.Get(e=> e.Cedula== user.Cedula)!= null)
              {
                user.Rol = "Operador";
              }
        return user;
    }
}