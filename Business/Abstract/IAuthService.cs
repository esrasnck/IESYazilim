using Core.Entities.Concrete;
using Core.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public  interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDt);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
    }
}
