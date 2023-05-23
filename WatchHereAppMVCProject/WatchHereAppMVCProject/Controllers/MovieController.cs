using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WatchHereAppMVCProject.Data;
using WatchHereAppMVCProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WatchHereAppMVCProject.Controllers
{
    public class MovieController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return View(movie);
        }

        //[HttpPost]
        //public async Task<IActionResult> Like(int id)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return Unauthorized();
        //    }

        //    var user = await _userManager.GetUserAsync(User);

        //    var movie = await _context.Movies.FindAsync(id);

        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    user.LikedMovies.Add(movie);

        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
