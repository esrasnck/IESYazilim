using Entities.Concrete.Xmls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Extensions;

namespace MVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var filePath = @"C:\Users\Esra SANCAK\source\repos\IESYazılım\MVCUI\OrnekXml.xml";
            string readFile = System.IO.File.ReadAllText(filePath);
            Transfer xmlToCsharp = readFile.FromXml<Transfer>();

            string csharpToXml = xmlToCsharp.ToXml();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
