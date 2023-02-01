using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Interfaces;
using Movies.Models;

namespace Movies.Controllers
{
    public class MovieController : Controller
    {
        //hardcoded movie list
        //private static List<Movie> Movielist = new List<Movie>
        //{
        //    new Movie("Star Wars: A New Hope", 1977, 4f),
        //    new Movie("Star Wars: The Empire Strikes Back", 1980, 4f),
        //    new Movie("Megamind", 2010, 5f),
        //};

        IDataAccessLayer dal = new MovieListDAL();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            Movie foundMovie = dal.GetMovie(id);

            if (foundMovie == null) return NotFound();

            return View();
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            dal.EditMovie(m);
            TempData["success"] = "Movie" + m.Title + " edited";


            return RedirectToAction("MultMovies", "Movie");
        } 

        public IActionResult Delete(int? id)
        {
            if (dal.GetMovie(id) == null) 
            {
                //validator
                ModelState.AddModelError("Title", "Cannot find movie to delete");
            }
            if (ModelState.IsValid)
            {
                //temp delete
                dal.RemoveMovie(id);
                TempData["success"] = "Movie deleted";
            }
            else 
            {
                return View();
            }
            return RedirectToAction("MultMovies", "Movie");
        }
        
        public IActionResult MultMovies()
        {
            return View(dal.GetMovies());
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
            //custom validation
            if (m.Title.Contains("The Room"))
            {
                ModelState.AddModelError("CustomError", "That Movie sucks, you cannot add it to the database");
            }

            if (ModelState.IsValid) 
            {
                dal.AddMovie(m); //dal method that adds movie
                TempData["Success"] = m.Title + " was added!"; //last through redirects
                return RedirectToAction("MultMovies", "Movie");
            }
            return View();
        }

        //search
        public IActionResult Search(string key) 
        {
            if (String.IsNullOrEmpty(key)) 
            {
                return View("MultMovies", dal.GetMovies());
            }
            //returns searched
            return View("MultMovies", dal.GetMovies().Where(c => c.Title.ToLower().Contains(key.ToLower())));
        }
    }
}
