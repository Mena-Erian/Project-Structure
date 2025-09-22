using Microsoft.AspNetCore.Mvc;
using Project_Structure.Models;

namespace Project_Structure.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet] // GET: baseUrl/Home/Index
        public IActionResult Index()
        {
            //return new ViewResult();
            
            return View(); // with the same name of action
            //return View(new Employee());
            //return View("Index");//View Name;
            //return View("Index", new Employee());
        }

        [HttpGet] // GET: baseUrl/Home/Index
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet] // GET: baseUrl/Home/Index
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet] // GET: baseUrl/Home/Index
        public IActionResult ContentUs()
        {
            return View();
        }
    }
}
