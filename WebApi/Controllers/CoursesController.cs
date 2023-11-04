namespace Name.Controllers;

using Base.Models;
using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class Courses : ControllerBase
    {

        private ICursoServices _CursoServices;
        

        public Courses(ICursoServices cursoServices)
        {
            _CursoServices = cursoServices;

        }


        [HttpGet("Get/{Idc}")]
        public async Task<IActionResult> Get(int IdC)
        {
            var result = _CursoServices.Get(IdC);
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
        public async Task<IActionResult> Add(Curso curso)
        {
            var result = _CursoServices.Add(curso);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

            
         
        }

        [HttpDelete("Delete/{IdC}")]
        public async Task<IActionResult> Delete(int IdC)
        {
            var result = _CursoServices.Delete(IdC);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

            
         
        }

        [HttpPut("Update/{IdC}")]
        public async Task<IActionResult> Update(int Idc, Curso curso)
        {
            var result = _CursoServices.Update(Idc,curso);
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
            var result = _CursoServices.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }

            
         
        }

        [HttpGet("GetMaterias/{Id}")]
        public async Task<IActionResult> GetMaterias(string Id)
        {
            var result = _CursoServices.GetMaterias(Id);
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
