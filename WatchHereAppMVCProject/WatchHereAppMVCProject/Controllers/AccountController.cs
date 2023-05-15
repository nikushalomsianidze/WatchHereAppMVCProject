using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            var result = await _userManager.CreateAsync(user);//this class UserManager<IdentityUser> creating async instance of user
            if (result.Succeeded)
            { 
                    
               await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
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
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,lockoutOnFailure:false);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
           
        }
    }
}
