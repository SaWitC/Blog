using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ViewModels;
using Blog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Blog.Data;
using Blog.ViewModels.AccountVM;
using Blog.Components.Services;
using Microsoft.AspNetCore.Html;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> usermanager, SignInManager<User> signInManager)
        {
            _userManager = usermanager;
            _signInManager = signInManager;
        }
        //done register login logout

       [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
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

        //[HttpGet]
        //public IActionResult SetTheme()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> SetTheme(string theme)
        //{
        //    var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
        //    user.Theme = theme;
        //    await _userManager.UpdateAsync(user);
        //    return RedirectToAction(nameof(Index));
        //}

        public async Task SetTheme(string theme)
        {
            var user =await _userManager.FindByNameAsync(User.Identity.Name);
            user.Theme = theme;
            IdentityResult resoult = await _userManager.UpdateAsync(user);
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePasswordAuthorise()
        {
            return View();
        }
        [Authorize]
        
        [HttpPost]
        public async Task<IActionResult> ChangePasswordAuthorise(ChangePasswordAuthoriseVM model)
        {
            if (model.name == null)
            {
                
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.name);
                if (user != null)
                {
                    IdentityResult result =await _userManager.ChangePasswordAsync(user, model.oldPass, model.NewPass);
                    if (result.Succeeded)
                    {
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction(nameof(Passwordchanged));
                    }
                }
                else
                {
                    return RedirectToAction("Error");
                }
                
            }
            ModelState.AddModelError("", "не верный пароль");
            return View(model);
        }

        [HttpGet]
        public IActionResult SendEmailMessageforChangePass()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailMessageforChangePass(ChangePasswordNonAuthoriseGetEmail model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user!=null)
                {
                    var token =await  _userManager.GeneratePasswordResetTokenAsync(user);

                    var callbackUrl = Url.Action("ChangePasswortNonAythorise", "Account", new { userId = user.Id, code = token },
                           protocol: Request.Scheme);

                    string message = $"<h2>Изменение пароля </h2>" +
                        $"<h3>для изменения пароля перейдите по ссылке</h3> <a href =\"{callbackUrl} \">вот ваша ссылка</a>";

                    await EmailMessageService.SendEmailMessageAsync("change password", model.Email,message);
                    return RedirectToAction(nameof(Passwordchanged));
                }
                else
                {
                    return RedirectToAction(nameof(Passwordchanged));
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ChangePasswortNonAythorise(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            ViewBag.userId = userId;
            if (user != null)
            {
                return View();
            }
            return View(nameof(Register));
               
        }
        [HttpPost]
        public async Task<IActionResult> ChangePasswortNonAythorise(ChangePasswordNonAuthorise model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.userId);
                if (user != null)
                {
                    var passwordvalidator = HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as IPasswordValidator<User>;

                    var passwordhaser = HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;
                    IdentityResult result = await passwordvalidator.ValidateAsync(_userManager, user, model.NewPass);
                    if (result.Succeeded)
                    {
                        user.PasswordHash = passwordhaser.HashPassword(user, model.NewPass);
                        await _userManager.UpdateAsync(user);
                        return RedirectToAction(nameof(Passwordchanged));
                    }
                }
            }
            return View(model);
        }

        public IActionResult Passwordchanged()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EmailConfirm()
        {
            return View();
        }

    }
}
