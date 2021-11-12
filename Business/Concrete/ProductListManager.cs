using Business.Abstract;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductListManager : IProductListService
    {
        IProductListDal _productListDal;
        public ProductListManager(IProductListDal productListDal)
        {
            _productListDal = productListDal;
        }
        public IResult Add(ProductList productList)
        {
            _productListDal.Add(productList);
            return new SuccessResult();
        }
    }
}
