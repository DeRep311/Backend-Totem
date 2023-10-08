namespace Name.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        [HttpGet("Get")]
        public async Task<IActionResult> GetUsers()
        {
            
            


            return Ok();
        } 
    }
}