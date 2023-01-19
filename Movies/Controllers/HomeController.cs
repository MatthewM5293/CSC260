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
            //return Redirect("https://lms.neumont.edu/courses/3404485/assignments/34816051");
        }

        public IActionResult Privacy(string pizza)
        {
            ViewBag.mypizza = pizza;
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
        
        public IActionResult ParamTest(int? id)
        {
            return Content($"id = {id?.ToString() ?? "NULL"}");
            // ?? = NULL coalescing operator If left is null, do the right thing
            // id? = NULL check if id is null, DO NOT do ToString() on right
            // if multiple perameters are sent int, the priority is: 
                //1. Form, 2. Route, 3. Query String
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}