using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SerialNumberManager : ISerialNumberService
    {
        ISerialNumberDal _serialNumberDal;
        public SerialNumberManager(ISerialNumberDal serialNumberDal)
        {
            _serialNumberDal = serialNumberDal;
        }
        public IResult Add(SerialNumber serialNumber)
        {
            // hata kontrolünü yap. refactör et
            _serialNumberDal.Add(serialNumber);

            return new SuccessResult();
        }
    }
}
