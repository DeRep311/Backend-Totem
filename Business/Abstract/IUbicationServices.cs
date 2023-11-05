using Base.Models;


public interface IUbicationServices
{

    public IResult Add(UbicationDTO Ubication);
    public IResult Delete(UbicationDTO ubication);

    public IDataResult<List<UbicationDTO>> GetAll();



    public IResult Update(UbicationDTO ubicacionnew);





}