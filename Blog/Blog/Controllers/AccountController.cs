using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ViewModels;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers
{
    public class AccountController : BaseController<AccountController>
    {
        public AccountController(UserManager<User> usermanager,
            SignInManager<User> signInManager) : base(null,
            null,
            null,
            null,
            null,
            usermanager,
            signInManager)
        {
        }
        //done register login logout

       [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegiserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Email = model.Email, UserName = model.UserName };//initialise object
                var resoult = await _userManager.CreateAsync(user,model.Password);//crete new user
                if (resoult.Succeeded)
                {
                    await _signInManager.SignInAsync(user,false);//add cockies
                    return RedirectToAction("Index", "ArticleModel");
                }
                else
                {
                    foreach (var x in resoult.Errors)
                    {
                        ModelState.AddModelError(string.Empty,x.Description);
                    }
                }
            }
            return View(model);
        }
        [Authorize]
        [HttpGet]
        public IActionResult EditPhone()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPhone(EditPhoneViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = model.PhoneNumber;
                IdentityResult resoult = await _userManager.UpdateAsync(user);
                if (resoult.Succeeded)
                {
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    ModelState.AddModelError("","что-то пошло не так");
                }
               
            }
            return View(model);
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(user);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result
                   = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "ArticleModel");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "ArticleModel");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditThemeModal(string Thema)
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            user.ThemeCode = Thema;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Account");
        }
    }
}
