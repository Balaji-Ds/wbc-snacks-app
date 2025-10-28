using Microsoft.AspNetCore.Mvc;

namespace LoginApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Simple authentication logic for demo
            if (username == "admin" && password == "password")
            {
                ViewBag.Message = "Login successful!";
                return View();
            }
            else
            {
                ViewBag.Message = "Invalid username or password.";
                return View();
            }
        }
    }
}