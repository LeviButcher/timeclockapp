using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController : Controller
    {
        public string Phone()
        {
            return "123123";
        }

        public string Address()
        {
            return "USA";
        }
    }
}
