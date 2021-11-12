using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RandomImageWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class V1Controller : ControllerBase
    {
        private static Random rnd = new Random();
        public IActionResult GetRandomImage()
        {
            int number = rnd.Next(0, 10);
            string bs = "";

            string[] fileImages = Directory.GetFiles("./Images");

            for (int i = 0; i < fileImages.Length;)
            {
                i += number;
                byte[] imageArray = System.IO.File.ReadAllBytes(fileImages[i]);
                bs = Convert.ToBase64String(imageArray);
                break;

            }
            return Ok(bs);
        }
    }
}

