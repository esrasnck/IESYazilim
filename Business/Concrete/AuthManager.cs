using Business.Abstract;
using Core.Entities.Concrete;
using Core.Results;
using Core.Utilities.Security.Hashing;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        IUserService _userService;
        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var IsExist = _userService.GetByEmail(userForLoginDto.Email);
            if(IsExist == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı.");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, IsExist.PasswordHash, IsExist.PasswordSalt))
            {
                return new ErrorDataResult<User>(IsExist,"Şifre hatalı");
            }
            return new SuccessDataResult<User>(IsExist, "Giriş başarılı");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            User user = new User();
            user.Email = userForRegisterDto.Email;
            user.FirstName = userForRegisterDto.FirstName;
            user.LastName = userForRegisterDto.LastName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kullanıcı kayıdı başarılı.");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) !=null)
            {
                return new ErrorResult("Kullanıcı var.");
            }
            return new SuccessResult();
        }
    }
}
