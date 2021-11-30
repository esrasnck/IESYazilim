using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<EfTransferDal>().As<ITransferDal>().SingleInstance();
            builder.RegisterType<TransferManager>().As<ITransferService>().SingleInstance();


            builder.RegisterType<EfProductListDal>().As<IProductListDal>().SingleInstance();
            builder.RegisterType<ProductListManager>().As<IProductListService>().SingleInstance();

            builder.RegisterType<EfCarrierDal>().As<ICarrierDal>().SingleInstance();
            builder.RegisterType<CarrierManager>().As<ICarrierService>().SingleInstance();

            builder.RegisterType<EfSerialNumberDal>().As<ISerialNumberDal>().SingleInstance();
            builder.RegisterType<SerialNumberManager>().As<ISerialNumberService>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();

    

        }
    }
}
