using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SQLTemporalTablesDemo.Models.ViewModels;

namespace SQLTemporalTablesDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginUser = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
                if (loginUser.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }
                ModelState.AddModelError(string.Empty, "Username or Passwrod is incorrect");
            }
            return View(model);
        }

        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
