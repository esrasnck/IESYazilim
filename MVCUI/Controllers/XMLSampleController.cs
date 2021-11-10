using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Extensions;

namespace MVCUI.Controllers
{
    public class XMLSampleController : Controller
    {

        // sonra
        public IActionResult Index()
        {

            var filePath = @"C:\Users\Esra SANCAK\source\repos\IESYazılım\MVCUI\OrnekXml.xml";
            string readFile = System.IO.File.ReadAllText(filePath);
            Transfer xmlToCsharp = readFile.FromXml<Transfer>();

            string csharpToXml = xmlToCsharp.ToXml();

            return View();
        }
    }
}
