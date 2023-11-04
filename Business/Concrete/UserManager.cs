using Base.Models;


public class UserManager : IUserServices
{

    private IUserDal _userDal;
    private IDocenteDal _docenteDal;

    private IEstudianteDal _estudianteDal;
    private IAdministradorDal _administradorDal;

    private IOperadorDal _operadorDal;
    

    public UserManager(IUserDal userDal, IDocenteDal docenteDal, IEstudianteDal estudianteDal, IAdministradorDal administradorDal, IOperadorDal operadorDal)
    {

        _userDal = userDal;
        _docenteDal = docenteDal;
        _estudianteDal = estudianteDal;
        _administradorDal = administradorDal;
        _operadorDal = operadorDal;
    }
  


    public IResult Add(Usuario user)
    {
        _userDal.Add(user);
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
      

        return new SuccessResult();
    }

    public IResult Delete(int cedula)
    {
        Usuario userDelet = _userDal.Get(e => e.Cedula == cedula);
        if (userDelet == null)
        {
            return new ErrorResult("Usuario no encontradp");
        }
        _userDal.Delete(userDelet);
        

        return new SuccessResult();
    }

    public IDataResult<Usuario> Get(int cedula)
    {
        Usuario user = _userDal.Get(e => e.Cedula == cedula);
        if (user == null)
        {
            return new ErrorDataResult<Usuario>("usuario no encontrado", null);
        }
        user= _userDal.GetUserRol(user);
       
        return new SuccessResultData<Usuario>(user);
    }

    public IDataResult<List<Usuario>> GetAll()
    {
        List<Usuario> user = _userDal.GetAll();
        if (user == null)
        {
            
            return new ErrorDataResult<List<Usuario>>("No existen usuarios", null);
        }
        user = _userDal.GetUserRolist(user);

        return new SuccessResultData<List<Usuario>>(user);
    }

    public IResult Update(int cedula, Usuario usernew)
    {
        Usuario userold = _userDal.Get(e => e.Cedula == cedula);
        if (userold == null)
        {
            return new ErrorResult();
        }
        _userDal.Update(usernew, userold);

        return new SuccessResult();
    }
}

