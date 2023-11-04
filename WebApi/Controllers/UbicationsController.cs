namespace Name.Controllers
{
    using Base.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class Ubication : ControllerBase
    {

        private IUbicationServices _UbicationManager;

        public Ubication(IUbicationServices Ubication)
        {
            _UbicationManager = Ubication;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUbications()
        {
            try
            {
                var result = _UbicationManager.GetAll();

                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (System.Exception r)
            {

                return BadRequest(r.Message);
            }
        }

        [HttpGet("Get/{codigo}")]
        public async Task<IActionResult> GetUbication(string codigo)
        {
            var result = _UbicationManager.GetById(codigo);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                System.Console.WriteLine(codigo);
                return BadRequest(result);
            }

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Ubicacione Ubication)
        {
            var result = _UbicationManager.Add(Ubication);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpDelete("Delete/{codigo}")]
        public async Task<IActionResult> Delete(string codigo)
        {

            var result = _UbicationManager.Delete(codigo);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpPut("Update/{codigo}")]

        public async Task<IActionResult> Update(string codigo, Ubicacione newUbication)
        {
            var result = _UbicationManager.Update(codigo, newUbication);

            if (result.Success)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}