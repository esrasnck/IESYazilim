using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarrierManager : ICarrierService
    {
        ICarrierDal _carrierDal;
        public CarrierManager(ICarrierDal carrierDal)
        {
            _carrierDal = carrierDal;
        }
        public IResult Add(Carrier carrier)
        {
            _carrierDal.Add(carrier);
            return new SuccessResult();
        }
    }
}
