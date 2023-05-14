using Microsoft.AspNetCore.Mvc;
using WatchHereAppMVCProject.Models;
using WatchHereAppMVCProject.Models;

namespace WatchHereAppMVCProject.Controllers
{
    public class AccountController : Controller
    {
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
    }
}
