using Base.Models;
using Core.DataAccess;
using DataAccess.DTOs;


public interface IMateriaDal:IEntityRepository<Materium>
{
    public List<MateriasDTO> Getbygroup(String NombredeGrupo);
    
}