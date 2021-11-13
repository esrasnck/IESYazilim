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
        public TransferManager(ITransferDal transferDal, ICarrierService carrierService, IProductListService productListService, ISerialNumberService serialNumberService)
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
                sourceGLN = xmlToCsharp.SourceGLN,
                destinationGLN = xmlToCsharp.DestinationGLN,
                actionType = xmlToCsharp.ActionType,
                shipTo = xmlToCsharp.ShipTo,
                documentDate = xmlToCsharp.DocumentDate,  // hata çıkabilir
                note = xmlToCsharp.Note,
                version = xmlToCsharp.Vesion

            };
            _transferDal.Add(transfer);
            foreach (var item in xmlToCsharp.Carrier)
            {
                Carrier carrier = new Carrier()
                {
                    transferid = transfer.id,
                    carrierLabel = item.CarrierLabel,
                    containerType = item.ContainerType

                };
                _carrierService.Add(carrier);

                ProductList productList = new ProductList()
                {
                    carrierid = carrier.carrierid,
                    GTIN = item.ProductList.GTIN,
                    lotNumber = item.ProductList.LotNumber,
                    productionDate = item.ProductList.ProductionDate,
                    expirationDate = item.ProductList.ExpirationDate,

                };
                _productListService.Add(productList);

                if (item.ProductList != null && item.ProductList.SerialNumber != null)
                    foreach (var seriNumberXml in item.ProductList.SerialNumber)
                    {
                        
                        SerialNumber serial = new SerialNumber()
                        {
                           productListid = productList.productListid,
                            serialNumber = seriNumberXml,
                        };
                        _serialNumberService.Add(serial);

                    }
            }
            return new SuccessResult("eklendi");
        }
    }
}
