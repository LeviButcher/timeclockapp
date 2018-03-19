using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeClock2.Models;
using TimeClock2.Repos.IRepos;
using TimeClock2.ViewModels;

namespace TimeClock2.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class VacationController : Controller
    {

        private readonly IVacationRepo _repo;


        public VacationController(IVacationRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            //Pass in a viewModel with the current date
            return View();
        }

        [HttpPost]
        public IActionResult Create(VacationViewModel vacation)
        {
            var newVacation = new Vacation()
            {
                StartDate = vacation.StartDate,
                EndDate = vacation.EndDate,
            };

            _repo.Add(newVacation);

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult List()
        {
            var vacations = _repo.GetAll();
            return View(vacations);
        }

        [HttpGet("{id}")]   
        public IActionResult Edit(int id)
        {
            var vacation =  _repo.Find(id);
            if (vacation == null)
            {
                return Content("Not found");
            }

            return View(vacation);
        }

        [HttpPut]
        public IActionResult Edit(Vacation vacation)
        {
            _repo.Update(vacation);

            return View("List");
        }
    }
}