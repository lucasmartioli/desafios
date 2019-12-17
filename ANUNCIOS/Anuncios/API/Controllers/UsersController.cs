using System;
using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public void SingUp([FromBody] User user)
        {
            var data = System.Text.Encoding.ASCII.GetBytes(user.Password);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            var hash = System.Text.Encoding.ASCII.GetString(data); 
            user.Password = hash;

            _userService.Create(user);
        }
    }
}