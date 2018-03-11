using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TimeClock4.Controllers
{
    [Authorize]
    public class VacationController : Controller
    {
        public IActionResult Index()
        {
            //List all the links to what you can do at a Vacation
            return View();
        }
    }
}