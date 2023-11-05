using Base.Models;
using Microsoft.AspNetCore.Mvc;

public class GroupController: ControllerBase
 {

    private IGroupServices _GroupServices;
    

    public GroupController(IGroupServices groupServices)
    {
        _GroupServices = groupServices;

    }
[Route("api/[controller]")]
    [HttpGet("Get/{IdG}")]

    public async Task<IActionResult> Get(String IdG)
    {
        var result = _GroupServices.Get(IdG);
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

    public async Task<IActionResult> Add(GrupoDTO group)
    {
        var result = _GroupServices.CreateGroup(group);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

    [HttpDelete("Delete/{IdG}")]

    public async Task<IActionResult> Delete(String IdG)
    {
        var result = _GroupServices.DeleteGroup(IdG);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

    [HttpPut("Update")]

    public async Task<IActionResult> Update(String idGrupoOld, GrupoDTO group)
    {
        var result = _GroupServices.UpdateGroup(idGrupoOld, group);
        if (result.Success)
        {
            return Ok(result.Message);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }

    [HttpGet("GetAll")]

    public async Task<IActionResult> GetAll()
    {
        var result = _GroupServices.GetAll();
        if (result.Success)
        {
            return Ok(result.Data);
        }
        else
        {
            return BadRequest(result.Message);
        }

        
     
    }
    
}