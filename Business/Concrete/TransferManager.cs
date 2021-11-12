using Business.Abstract;
using Core.Extensions;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class TransferManager : ITransferService
    {
        ITransferDal _transferDal;
        ICarrierService _carrierService;
        IProductListService _productListService;
        ISerialNumberService _serialNumberService;
        public TransferManager(ITransferDal transferDal,ICarrierService carrierService, IProductListService productListService, ISerialNumberService serialNumberService)
        {
            _transferDal = transferDal;
            _carrierService = carrierService;
            _productListService = productListService;
            _serialNumberService = serialNumberService;
        }


        public IResult Add(string filePath)
        {
            string readFile = System.IO.File.ReadAllText(filePath);
            var xmlToCsharp = readFile.FromXml<Entities.Concrete.Xmls.Transfer>();
            Transfer transfer = new Transfer()
            {
                // maplemece

                note = xmlToCsharp.Note
            };
            foreach (var item in xmlToCsharp.Carrier)
            {
                Carrier carrier = new Carrier()
                {
                    carrierLabel = item.CarrierLabel
                };

                ProductList productList = new ProductList()
                {
                    productionDate = item.ProductList.ProductionDate
                };

                if (item.ProductList != null && item.ProductList.SerialNumber != null)
                    foreach (var seriNumberXml in item.ProductList.SerialNumber)
                    {
                        SerialNumber serial = new SerialNumber()
                        {
                            serialNumber = seriNumberXml
                        };
                    }
            }

            _transferDal.Add(transfer);

            return new SuccessResult("eklendi");
        }
    }
}
