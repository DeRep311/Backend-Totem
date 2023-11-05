using Base.Models;

public class AssignManager : IAssignServices
{
    private IHorarioDal _HorarioDal;
    private IUbicationDal _UbicacionDal;
    private IMateriaDal _MateriaDal;
    private IHorarioMateriaDal _HorarioMateriaDal;
    private IUbicationMateriaDal _UbicacionMateriaDal;
    private IGroupServices _GroupServices;
    public AssignManager(IHorarioDal HorarioDal, IUbicationDal UbicacionDal, IMateriaDal MateriaDal, IHorarioMateriaDal HorarioMateriaDal, IUbicationMateriaDal UbicacionMateriaDal, IGroupServices GroupServices)
    {
        _HorarioDal = HorarioDal;
        _UbicacionDal = UbicacionDal;
        _MateriaDal = MateriaDal;
        _HorarioMateriaDal = HorarioMateriaDal;
        _UbicacionMateriaDal = UbicacionMateriaDal;
    }

    public IResult AssignHorarytoMateria(String group, String Materia, int Horario)
    {
       var result = _GroupServices.Get(group);
       if (result !=null)
       {
            var ResultHorario= _HorarioDal.Get(e=> e.IdH == Horario);
            if (ResultHorario != null)
            {
               var Matery= result.Data.Materias.Find(e=> e.NombreMateria == Materia);

                if(Matery != null)
                {
               var ResultHorarioMateria = _HorarioMateriaDal.Get(e=> e.IdH == ResultHorario.IdH && e.NombreMateria == Matery.NombreMateria);
                          if (ResultHorarioMateria == null)
                          {
                            
                            _HorarioMateriaDal.Add(new HorarioGrupoCurso{
                                IdH = ResultHorario.IdH, NombreGrupo = result.Data.NombreGrupo, NombreMateria = Matery.NombreMateria, IdC = result.Data.Idc});
                            return new SuccessResult("Se asigno correctamente");
                          }
                          else
                          {
                            return new ErrorResult("Ya se encuentra asignado");
                          }
                   
                }
                else
                {
                     return new ErrorResult("No se encontro la materia");
                }
                
            }
          
                return new ErrorResult("No se encontro el horario");
        
        
       }
         else
         {
              return new ErrorResult("No se encontro el grupo");
         }
    }

    public IResult AssignUbicationtoMateria(String IdU, String group, String Nmateria)
    {
        var result = _UbicacionDal.Get(e=> e.CodigoUbicaciones == IdU);
        if (result != null)
        {
            var grupo = _GroupServices.Get(group);
            var resultMateria = grupo.Data.Materias.Find(e=> e.NombreMateria == Nmateria);
            if (resultMateria != null)
            {
                var resultUbicationMateria = _UbicacionMateriaDal.Get(e=> e.CodigoUbicaciones == result.CodigoUbicaciones && e.NombreMateria == resultMateria.NombreMateria);
                if (resultUbicationMateria == null)
                {
                    _UbicacionMateriaDal.Add(new CursoHorarioUbicacion{
                        CodigoUbicaciones = result.CodigoUbicaciones, NombreMateria = resultMateria.NombreMateria, IdC = grupo.Data.Idc, IdH = resultMateria.Horarios.IdH
                    });
                    return new SuccessResult("Se asigno correctamente");
                }
                else
                {
                    return new ErrorResult("Ya se encuentra asignado");
                }
            }
            else
            {
                return new ErrorResult("No se encontro la materia");
            }
        }
        else
        {
            return new ErrorResult("No se encontro la ubicacion");
        }
    }
}