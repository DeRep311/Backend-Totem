using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

public class MateriaController : ControllerBase
 {

    private IMateriaServices _MateriaServices;
    

    public MateriaController(IMateriaServices materiaServices)
    {
        _MateriaServices = materiaServices;

    }

    [HttpGet("Get/{IdM}")]

    public async Task<IActionResult> Get(int IdM)
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

    public async Task<IActionResult> Add(Materium materia)
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

    public async Task<IActionResult> Delete(int IdM)
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
    public async Task<IActionResult> Update(int IdM, Materium newmateria)
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

    
    
}