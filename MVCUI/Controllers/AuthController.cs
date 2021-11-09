using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCUI.Controllers
{
    public class AuthController : Controller
    {

        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Register()
        {
            return View();
        }


        // refacktor edilecek
        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegister)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userExist = _authService.UserExists(userForRegister.Email);
            if (!userExist.Success)
            {
                return View();
            }
            var registerResult = _authService.Register(userForRegister);
            if (registerResult.Success)
            {

                return View();
            }
            return View();
            
        }

        public IActionResult Login()
        {
            return View();
        }


        // refaktör edilecek
        [HttpPost]
        public IActionResult Login(UserForLoginDto userForLogin)
        {
            var userToLogin = _authService.Login(userForLogin);
            if (!userToLogin.Success)
            {
                return View();
            }
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
