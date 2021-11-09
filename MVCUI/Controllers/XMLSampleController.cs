using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUI.Controllers
{
    public class XMLSampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
