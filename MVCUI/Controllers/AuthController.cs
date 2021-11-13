using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserForRegisterDto userForRegister)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userExist = _authService.UserExists(userForRegister.Email);
            if (!userExist.Success)
            {
                ViewBag.userExist = userExist.Message;
                
                return View();
            }
            var registerResult = _authService.Register(userForRegister);
            if (registerResult.Success)
            {
                ViewBag.registerResult = registerResult.Message;
                return View();
            }

            return View();
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserForLoginDto userForLogin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userToLogin = _authService.Login(userForLogin);
            if (!userToLogin.Success)
            {
                ViewBag.userToLogin = userToLogin.Message;
                return View();
            }
            ViewBag.userToLogin = userToLogin.Message;
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
