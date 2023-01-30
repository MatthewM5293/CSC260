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
        public IActionResult Edit(int? id)
        {
            //load current Model
            if (id == null) return NotFound();
               
            Movie foundMovie = Movielist.Where(m => m.Id == id).FirstOrDefault();
            
            if (foundMovie == null) return NotFound();

            return View(foundMovie);
        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            //Save Edited Movie
            int i;
            string temp = m.Title;
            i = Movielist.FindIndex(x => x.Id == m.Id);
            if (i == -1) return NotFound();

            if (m.Title != null && m.Year != null && m.Rating != null)
            {

                Movielist[i] = m;
                //allows user to see what changed
                TempData["success"] = "Movie " + temp + " updated";
                return RedirectToAction("MultMovies", "Movie");
            }
            else 
            {
                TempData["success"] = "movie properties cannot be null!";
                return RedirectToAction("MultMovies", "Movie");
            }
        } 
        public IActionResult Delete(Movie m)
        {
            //    int i;

            //    i = Movielist.FindIndex(x => x.Id == m.Id);
            //    if (i == -1) return NotFound();

            //    TempData["success"] = "Movie " + Movielist[i].Title + " deleted";
            //    Movielist.RemoveAt(i);

            if (dal.GetMovie(m.Id) == null) 
            {
                //validator
                ModelState.AddModelError("Title", "Cannot find movie to delete");
            }
            if (ModelState.IsValid)
            {
                //temp delete
                dal.RemoveMovie(m.Id);
                TempData["success"] = "Movie deleted";

                return RedirectToAction("MultMovies", "Movie");
            }
            else 
            {
                return View();
            }
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
                dal.AddMovie(m); //dal method
                TempData["Success"] = m.Title + " was added!"; //last through redirects
                return RedirectToAction("MultMovies", "Movie");
            }
            return View();
        }
    }
}
