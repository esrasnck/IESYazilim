using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Extensions;
using Business.Abstract;




namespace MVCUI.Controllers
{
    public class XMLSampleController : Controller
    {

        ITransferService _transferService;
        public XMLSampleController(ITransferService transferService)
        {
            _transferService = transferService;

        }
        public IActionResult Index()
        {

            var filePath = @"C:\Users\Esra SANCAK\source\repos\IESYazılım\MVCUI\OrnekXml.xml";
            var result = _transferService.Add(filePath);
            var esra = result;
            //string readFile = System.IO.File.ReadAllText(filePath);
            //Transfer xmlToCsharp = readFile.FromXml<Transfer>();

            //string csharpToXml = xmlToCsharp.ToXml();

            return View();
        }
        //[HttpPost]
        //public IActionResult Index(string filePath)
        //{
        //    var result = _transferService.Add(filePath);
        //    if (result.Success)
        //    {
        //        return View(result);
        //    }
        //    return View();
        //}
    }
}
