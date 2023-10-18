using DataAccess.Models;

public interface IHorariosServices 

{
    public IResult CreateHorario(Horario horario);
    public IResult DeleteHorary(int IdH);

    public IResult UpdateHorary(int IdH, Horario horarionew);

    public IDataResult<Horario> GetHorary(int idH);
    
    
}