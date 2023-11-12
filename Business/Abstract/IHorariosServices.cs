using Base.Models;


public interface IHorariosServices 

{
    public IDataResult<int> CreateHorario(Horarios horario);
    public IResult DeleteHorary(int IdH);

    public IResult UpdateHorary(int IdH, Horarios horarionew);

    public IDataResult<Horarios> GetHorary(int idH);

    public IDataResult<List<Horarios>> GetAllHorary();
    
    
}