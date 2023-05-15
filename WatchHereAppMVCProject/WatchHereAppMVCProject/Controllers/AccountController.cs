using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WatchHereAppMVCProject.Models;
using WatchHereAppMVCProject.Models;

namespace WatchHereAppMVCProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();
            return View(registerViewModel);
        }

        [HttpPost] 
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new User { UserName = model.Name, Email = model.Email, Name = model.Name };
            var result = await _userManager.CreateAsync(user,model.Password);//this class UserManager<IdentityUser> creating async instance of user
            if (result.Succeeded)
            { 
                    
               await _signInManager.SignInAsync(user, isPersistent: false);
                return View("~/Views/Home/Index.cshtml");
            }
            return View(model);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
             
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                //  return View("~/Views/Home/Index.cshtml");
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);

        }
        [HttpPost]
        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
