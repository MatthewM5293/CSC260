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

            if (m.Title != null)
            {

                Movielist[i] = m;
                //allows user to see what changed
                TempData["success"] = "Movie " + temp + " updated";
                return RedirectToAction("MultMovies", "Movie");
            }
            else 
            {
                //my delete method
                Movielist.RemoveAt(i);

                TempData["success"] = temp  + " was removed!";
                return RedirectToAction("MultMovies", "Movie");
            }
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
