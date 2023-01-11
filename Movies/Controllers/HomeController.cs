using Microsoft.AspNetCore.Mvc;
using Movies.Models;
using System.Diagnostics;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private static int intCount = 0;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Page";
            return View();
        }
        
        public IActionResult Future()
        {
            return View();
        }

        public IActionResult Input()
        {

            ViewData["Title"] = "Input Form";
            return View();
        } 

        public IActionResult Output(string FirstName, string LastName)
        {
            ViewBag.FN = FirstName;
            ViewBag.LN = LastName;
            return View();
        }

        public IActionResult Counter()
        {
            ViewBag.count = intCount++;
            ViewData["Count"] = intCount;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}