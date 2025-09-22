using Microsoft.AspNetCore.Mvc;

namespace Project_Structure.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
