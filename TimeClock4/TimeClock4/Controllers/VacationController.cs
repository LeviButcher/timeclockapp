using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeClock4.EF;
using TimeClock4.Entity;
using TimeClock4.ViewModels.VacationViewModels;

namespace TimeClock4.Controllers
{
    [Authorize]
    public class VacationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VacationController(UserManager<ApplicationUser> userManager)
        {
            _context = new ApplicationDbContext();
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //List all the links to what you can do at a Vacation
            return View();
        }

        [HttpGet]
        public IActionResult CreateVacation()
        {
            //List all the links to what you can do at a Vacation
            return View();
        }

        [HttpPost]
        public IActionResult CreateVacation(CreateVacationViewModel model)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            //List all the links to what you can do at a Vacation
            if (ModelState.IsValid)
            {
                var vacation = new Vacation
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Reason = model.Reason,
                    UserId = user.Result.Id
                    
                };
                _context.Vacations.Add(vacation);
                var result = _context.SaveChanges();
                if (result == 1)
                {
                    //Redirect to the details view
                    return RedirectToAction("DetailVacation", new {id = vacation.Id});
                }

            }
            return View();
        }

        [HttpGet]
        public IActionResult DetailVacation(int id)
        {
            Vacation vacationRecord = _context.Vacations.Find(id);
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var supervisor = _userManager.FindByIdAsync(user.Result.SupervisorId);

            DetailVacationViewModel vacationView = new DetailVacationViewModel
            {
                StartDate = vacationRecord.StartDate,
                EndDate = vacationRecord.EndDate,
                Approval = vacationRecord.Approval,
                DateCreate = vacationRecord.DateCreated,
                Reason = vacationRecord.Reason,
                Supervisor = supervisor != null ? supervisor.Result.Email : "No Supervisor"
            };

            return View(vacationView);
        }

        [HttpGet]
        public IActionResult WaitingForApprovalVacations()
        {
            ViewData["Header"] = "Waiting for Approval Vacations";
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var supervisor = _userManager.FindByIdAsync(user.SupervisorId).Result;

            var vacations = _context.Vacations.Where(x => x.UserId == user.Id && x.Approval == ApprovalType.Waiting);

            var waitingVacations = new List<DetailVacationViewModel>();

            foreach (var vacation in vacations)
            {
                waitingVacations.Add(new DetailVacationViewModel
                {
                    RequestBy = user.Email,
                    DateCreate = vacation.DateCreated,
                    StartDate = vacation.StartDate,
                    Reason = vacation.Reason,
                    Approval = vacation.Approval,
                    Supervisor = supervisor.Email,
                    EndDate = vacation.EndDate,
                    Id = vacation.Id
                });
            }

            return View("ListVacations", waitingVacations);
        }

        [HttpGet]
        public IActionResult UpcomingApprovedVacation()
        {
            ViewData["Header"] = "Approved Upcoming Vacations";
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var supervisor = _userManager.FindByIdAsync(user.SupervisorId).Result;

            var vacations = _context.Vacations.Where(x => x.UserId == user.Id
                                                          && x.Approval == ApprovalType.Approved
                                                          && x.StartDate >= DateTime.Today);

            var approvedVacations = new List<DetailVacationViewModel>();

            foreach (var vacation in vacations)
            {
                approvedVacations.Add(new DetailVacationViewModel
                {
                    RequestBy = user.Email,
                    DateCreate = vacation.DateCreated,
                    StartDate = vacation.StartDate,
                    Reason = vacation.Reason,
                    Approval = vacation.Approval,
                    Supervisor = supervisor.Email,
                    EndDate = vacation.EndDate,
                    Id = vacation.Id
                });
            }

            return View("ListVacations", approvedVacations);
        }

        [HttpGet]
        [Authorize(Roles = "Supervisor")]
        public IActionResult ListVacationsWaitingForApproval()
        {
            ViewData["Header"] = "Vacations to Approve";
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            

            var vacations = _context.Vacations.Where(x => x.User.SupervisorId == user.Id 
                                                          && x.Approval == ApprovalType.Waiting
                                                          && x.StartDate > DateTime.Today).ToList();
            

            var waitingVacations = new List<DetailVacationViewModel>();

            foreach (var vacation in vacations)
            {
                var requestUser = _userManager.FindByIdAsync(vacation.UserId).Result;
                waitingVacations.Add(new DetailVacationViewModel
                {
                    RequestBy =  requestUser.Email,
                    DateCreate = vacation.DateCreated,
                    StartDate = vacation.StartDate,
                    Reason = vacation.Reason,
                    Approval = vacation.Approval,
                    Supervisor = user.Email,
                    EndDate = vacation.EndDate,
                    Id = vacation.Id
                });
            }
            return View("ListVacations", waitingVacations);
        }

        [HttpGet]
        [Authorize(Roles = "Supervisor")]
        public IActionResult ApproveOrDenyVacation(int id)
        {
            ViewData["Header"] = "Vacation to Approve or Deny";
            var supervisor = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var vacation = _context.Vacations.Find(id);
            var requestUser = _userManager.FindByIdAsync(vacation.UserId).Result;

            var vacationForView = new ApproveOrDenyVacationViewModel
            {
                RequestBy = requestUser.Email,
                DateCreate = vacation.DateCreated,
                StartDate = vacation.StartDate,
                Reason = vacation.Reason,
                Approval = vacation.Approval,
                Supervisor = supervisor.Email,
                EndDate = vacation.EndDate,
                Id = vacation.Id
            };


            return View(vacationForView);
        }

        [HttpPost]
        [Authorize(Roles = "Supervisor")]
        public IActionResult ApproveOrDenyVacation(ApproveOrDenyVacationViewModel model)
        {
            ViewData["Header"] = "Vacation to Approve or Deny";

            if (ModelState.IsValid)
            {
                var vacationToUpdate = _context.Vacations.Find(model.Id);

                vacationToUpdate.Approval = model.Approval;

                _context.SaveChanges();
                return RedirectToAction("ListVacationsWaitingForApproval");
            }

            return View(model);
        }
    }
}