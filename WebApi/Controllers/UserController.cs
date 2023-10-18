namespace Name.Controllers
{
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userManager;

        public UserController(IUserServices user)
        {
            _userManager = user;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsers()
        {
            var result = _userManager.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("Get/{cedula}")]

        public async Task<IActionResult> GetUser(int cedula){

         
            var result = _userManager.Get(cedula);
            if (result.Success)
            {
                return Ok(result);
            }else{
                System.Console.WriteLine(cedula);
                return BadRequest(result);
            }

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add (Usuario user){
            var result=_userManager.Add(user);

            if (result.Success)
            {
                return Ok();
                
            }else{
                return BadRequest();
            }

           

        }

        [HttpDelete("Delete/{cedula}")]
        public async Task<IActionResult> Delete (int cedula){

            var result=_userManager.Delete(cedula);

            if (result.Success)
            {
                return Ok();
                
            }else{
                return BadRequest();
            }

        }

        




    }
}