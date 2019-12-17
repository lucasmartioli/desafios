using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : Controller
    {
        private static bool Logged { get; set;  } = false;

        public void SingIn() => Logged = true;
        public bool IsLogged() => Logged;
    }
}