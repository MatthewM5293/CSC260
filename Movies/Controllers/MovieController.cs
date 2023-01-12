using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> Movelist = new List<Movie>
        {
            new Movie("Star Wars: A New Hope", 1977, 4f),
            new Movie("Star Wars: The Empire Strikes Back", 1980, 4f),
            new Movie("Megamind", 2010, 5f),
        };

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult MultMovies()
        {
            return View(Movelist);
        }
        
        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Puss in Boots", 2022, 5f);
            return View(m);
        }
    }
}
