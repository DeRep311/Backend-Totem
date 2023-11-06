
using Base.Models;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
    [ApiController]
public class MateriaController : ControllerBase
 {

    private IMateriaServices _MateriaServices;
    private IAssignServices _AssignServices;
    

    public MateriaController(IMateriaServices materiaServices, IAssignServices assignServices)
    {
        _MateriaServices = materiaServices;
        _AssignServices = assignServices;

    }


    public async Task<IActionResult> Get(String IdM)
    {
        var result = _MateriaServices.Get(IdM);
        if (result.Success)
        {
            return Ok(result.Data);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

    [HttpPost("Add")]

    public async Task<IActionResult> Add([FromBody] Materium materia)
    {
        var result = _MateriaServices.Add(materia);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

    [HttpDelete("Delete/{IdM}")]

    public async Task<IActionResult> Delete(String IdM)
    {
        var result = _MateriaServices.Delete(IdM);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

    [HttpPut("Update/{IdM}")]
    public async Task<IActionResult> Update(String IdM, Materium newmateria)
    {
        var result = _MateriaServices.Update(IdM,newmateria);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

    [HttpPost("Assign")]

    public async Task<IActionResult> Assign(AssignMateriaDTO assign)
    {
        var result = _AssignServices.AssignHorarytoMateria(assign.IdG, assign.IdM, assign.IdH);
        if(result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

   

    
    
}

public class AssignMateriaDTO
{
    public String IdM { get; set; }
    public int IdH { get; set; }

    public String IdG { get; set; }

}