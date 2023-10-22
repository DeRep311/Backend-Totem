namespace Name.Controllers
{
    using DataAccess.Models;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userManager;
        private IAuthServices _AuthManager;

        public UserController(IUserServices user, IAuthServices authServices)
        {
            _userManager = user;
            _AuthManager = authServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsers()
        {
          try
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
          catch (System.Exception r)
          {
            
            return BadRequest(r.Message);
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

        [HttpPost("Auth")]

        public async Task<IActionResult> Auth (AuthDTO data){

            var result = _AuthManager.Login(data);

            if (result.Success)
            {
                return Ok(result);
                
            }
            return BadRequest(result);

        }

        




    }
}