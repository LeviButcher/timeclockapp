using Microsoft.AspNetCore.Mvc;

namespace TimeClock4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestView()
        {

            return View();
        }
    }
}