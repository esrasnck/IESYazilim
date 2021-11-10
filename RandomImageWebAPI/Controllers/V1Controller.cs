using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RandomImageWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class V1Controller : ControllerBase
    {

        public IActionResult GetRandomImage()
        {
            Random rnd = new Random();
            using(HttpClient client = new HttpClient())
            {
          
            }

            return Ok();
        }
    }
}
