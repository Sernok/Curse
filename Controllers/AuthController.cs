using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "login12345" && password == "password12345")
            {
                return RedirectToAction("Dashboard");
            }
            ViewBag.Error = "Invalid login attempt";
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
