using System.Collections.Generic;
using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : BaseController
    {
        private readonly AdService _adService;

        public AdsController(AdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ad>> Get()
        {
            if (!IsLogged())
                return Unauthorized();
            
            return _adService.Get();
        }
    }
}