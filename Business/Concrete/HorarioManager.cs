using Base.Models;

public class HorarioManager : IHorariosServices
{


    private IHorarioDal _HorarioDal;

    public HorarioManager(IHorarioDal HorarioDal)
    {

        _HorarioDal = HorarioDal;

    }


    public IDataResult<int> CreateHorario(Horarios horario)
    {


        _HorarioDal.Add(horario);

        var result2 = _HorarioDal.GetId();
        return new SuccessResultData<int>(result2,"Se creo correctamente");


    }

    public IResult CreaterawHorary(List<Horarios> horarios)
    {

        foreach (var item in horarios)
        {
            this.CreateHorario(item);
        }
        return new SuccessResult();


    }

    public IResult DeleteHorary(int id_h)
    {
        var result = this.GetHorary(id_h);
        if (result.Success)
        {
            _HorarioDal.Delete(e => e.id_h == id_h);
            return new SuccessResult();

        }
        return new ErrorResult("Horario no encontrado");

    }


    public IDataResult<Horarios> GetHorary(int id_h)
    {
        var result = _HorarioDal.Get(e => e.id_h == id_h);
        if (result != null)
        {
            return new SuccessResultData<Horarios>(result);
        }
        return new ErrorDataResult<Horarios>("Horario no encontrado", null);

    }

    public IResult UpdateHorary(int id_h, Horarios horarionew)
    {
        var result = this.GetHorary(id_h);
        if (result.Success)
        {
            _HorarioDal.Update(horarionew, e => e.id_h == id_h);
            return new SuccessResult();

        }
        return new ErrorResult("Horario no encontrado");
    }

    public IDataResult<List<Horarios>> GetAllHorary()
    {
        var result = _HorarioDal.GetAll();
        if (result != null)
        {
            return new SuccessResultData<List<Horarios>>(result);
        }
        return new ErrorDataResult<List<Horarios>>();
    }
}