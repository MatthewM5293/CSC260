using Microsoft.AspNetCore.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        //hardcoded movie list
        private static List<Movie> Movielist = new List<Movie>
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
            return View(Movielist);
        }
        
        public IActionResult DisplayMovie()
        {
            Movie m = new Movie("Puss in Boots", 2022, 5f);
            return View(m);
        }

        [HttpGet] //loading create page
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //saving create page
        public IActionResult Create(Movie m)
        {
            if (m.Title != null && m.Year != null && m.Rating != null) 
            {
                Movielist.Add(m); //adds movie to list
                TempData["Success"] = "Movie added!"; //last through redirects
                return RedirectToAction("MultMovies", "Movie");
            }
            return View();
        }
    }
}
