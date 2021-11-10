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
    public class TransferManager:ITransferService
    {
        ITransferDal _transferDal;
        public TransferManager(ITransferDal  transferDal)
        {
            _transferDal = transferDal;
        }


        public IResult Add(string filePath)
        {
            string readFile = System.IO.File.ReadAllText(filePath);
            Transfer xmlToCsharp = readFile.FromXml<Transfer>();
            _transferDal.Add(xmlToCsharp);

            return new SuccessResult("eklendi");
        }
    }
}
