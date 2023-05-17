using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using WatchHereAppMVCProject.Data;

namespace WatchHereAppMVCProject.Controllers
{
    public class MovieController : Controller
    {

        private readonly ApplicationDbContext _context;


        public MovieController(ApplicationDbContext context)
        {
            _context = context;
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

        // Other actions for CRUD operations if needed
    }

}
