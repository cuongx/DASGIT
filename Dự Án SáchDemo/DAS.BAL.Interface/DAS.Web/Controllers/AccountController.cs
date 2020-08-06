using DAS.Domain.Responses.Account;
using DAS.Domain.Resquests.Account;
using DAS.Web.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS.Web.Controllers
{
    public class AccountController:Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Account/Login")]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var loginRequest = new LoginRequest()
                {
                    Email = model.Email,
                    Password = model.Password
                };
                var result = ApiHelper<LoginResult>.HttpPostAsync($"{Helper.ApiUrl}account/login", loginRequest);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Category");
                }
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Account/Register")]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var register = new RegisterRequest()
                {
                    Email = model.Email,
                    Password = model.Password
                    
                };
                var result = new RegisterResult();
                 result = ApiHelper<RegisterResult>.HttpPostAsync($"{Helper.ApiUrl}account/register", register);
                if (result.Success)
                {
                    return RedirectToAction("Index", "Category");
                }
                ModelState.AddModelError("", result.Message);
                return View();
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            var result = true;
            return Json(new { result});
        }
    }
}
