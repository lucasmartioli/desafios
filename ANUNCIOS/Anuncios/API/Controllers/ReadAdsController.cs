using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using API.Model;
using API.Service;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadAdsController : BaseController
    {
        private readonly AdService _adService;

        public ReadAdsController(AdService adService)
        {
            _adService = adService;
        }

        [HttpPost]
        public ActionResult ReadAds(Parameters parameters)
        {
            if (!IsLogged())
                return Forbid();

            var urlParameters = new Dictionary<string, string> {{"q", parameters.ProductName}};
            var webCrawler = new WebCrawler($"https://{parameters.SearchRegion.UfState}.olx.com.br", $"regiao-de-{parameters.SearchRegion.City}", urlParameters);
            
            var ads = webCrawler.Read();

            foreach (var ad in ads)
            {
                _adService.Create(ad);
            }

            return NoContent();
        }
    }
}