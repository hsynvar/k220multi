using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
       private readonly SignInManager<User> _signInManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private readonly UserManager<User> _userManager;

        public IActionResult Login()
        {
            return View();
        }
         public IActionResult Register()
        {
            return View();
        }

       

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
          var user =   await  _userManager.FindByEmailAsync(model.Email);
          if (user!= null)
          {
            return View();
          }
          User newUser = new()
          {
            UserName= model.Email,
            FirstName= model.FirstName,
            LastName= model.LastName,
            Email= model.Email

          };

          IdentityResult result =  await _userManager.CreateAsync(newUser, model.Password);
          if (result.Succeeded)
          {
            return RedirectToAction("Login");
            
          }
           
            return View();
        }

       
    }
}