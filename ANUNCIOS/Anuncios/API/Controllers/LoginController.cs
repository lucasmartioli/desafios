using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(user.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            var hash = System.Text.Encoding.ASCII.GetString(data);

            var foundUser = _userService.GetByLogin(user.Login);
            if (foundUser == null || foundUser.Password != hash) return Unauthorized();
            
            SingIn();
            
            return Ok();

        }
    }
}