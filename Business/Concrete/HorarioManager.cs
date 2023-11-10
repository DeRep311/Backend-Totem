using Base.Models;

public class HorarioManager : IHorariosServices
{


    private IHorarioDal _HorarioDal;

    public HorarioManager(IHorarioDal HorarioDal)
    {

        _HorarioDal = HorarioDal;

    }


    public IResult CreateHorario(Horario horario)
    {
        var result = _HorarioDal.Get(e=> e==horario);
        if (result==null)
        {
            _HorarioDal.Add(horario);
            return new SuccessResult();
            
        }
        return new ErrorResult("Horario ya existente");
    }

    public IResult CreaterawHorary(List<Horario> horarios){
        foreach (var item in horarios)
        {
            this.CreateHorario(item);
        }
        return new SuccessResult();


    }

    public IResult DeleteHorary(int IdH)
    {
        var result = this.GetHorary(IdH);
        if (result.Success)
        {
            _HorarioDal.Delete(e=> e.IdH == IdH);
            return new SuccessResult();
            
        }
        return new ErrorResult("Horario no encontrado");
        
    }


    public IDataResult<Horario> GetHorary(int IdH)
    {
        var result = _HorarioDal.Get(e => e.IdH == IdH);
        if (result != null)
        {
            return new SuccessResultData<Horario>(result);
        }
        return new ErrorDataResult<Horario>();
        
    }

    public IResult UpdateHorary(int idH, Horario horarionew)
    {
        var result = this.GetHorary(idH);
        if (result.Success)
        {
            _HorarioDal.Update(horarionew, e=> e.IdH == idH);
            return new SuccessResult();
            
        }
        return new ErrorResult("Horario no encontrado");
    }

    public IDataResult<List<Horario>> GetAllHorary()
    {
        var result = _HorarioDal.GetAll();
        if (result != null)
        {
            return new SuccessResultData<List<Horario>>(result);
        }
        return new ErrorDataResult<List<Horario>>();
    }
}