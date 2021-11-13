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

            if (result.Success)
            {
                ViewBag.result = result.Success;
                return View();
            }

            return View();
        }


        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index2(string filePath)
        {

            var xml = XmlExtensions.ToXml(filePath);
            ViewBag.xmlview = xml;
            return View();
        }
    }
}
