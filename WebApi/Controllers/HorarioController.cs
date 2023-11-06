namespace Name.Controllers
{
    using Base.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private IHorariosServices _HorarioServices;

        public HorarioController(IHorariosServices Horario)
        {
            _HorarioServices = Horario;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _HorarioServices.GetAllHorary();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
            
         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _HorarioServices.GetHorary(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
            
         
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Horario horario)
        {
            var result = _HorarioServices.CreateHorario(horario);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
            
         
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Horario horario)
        {
            var result = _HorarioServices.UpdateHorary(id, horario);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
            
         
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = _HorarioServices.DeleteHorary(id);
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
}