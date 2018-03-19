using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TimeClock4.EF;
using TimeClock4.Entity;
using TimeClock4.Utilities;
using TimeClock4.ViewModels.ClockInViewModels;

namespace TimeClock4.Controllers
{
    [Authorize]
    public class ClockInController : Controller
    {
        private const DayOfWeek Startoftimesheet = DayOfWeek.Monday;
        //How many days later is the end of the timesheet
        private const int Endoftimsheet = 6;

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClockInController(UserManager<ApplicationUser> userManager)
        {
            _context = new ApplicationDbContext();
            _userManager = userManager;
        }

        public IActionResult Index(bool In, DateTime time)
        {
            var model = new ClockInRedirectViewModel
            {
                In = In,
                Time = time
            };
            

            return View(model);
        }

        [HttpGet]
        public IActionResult ClockIn()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult();
            var timeSheet = FindTimeSheet(user.Id);
            ClockIn clockIn = null;

            if (_context.ClockIns.Any(x => x.TimeSheetId == timeSheet.Id))
            {
                if (_context.ClockIns.Any(x => x.TimeSheetId == timeSheet.Id && x.ClockOutTime == null))
                {
                    clockIn = _context.ClockIns.Last(x => x.TimeSheetId == timeSheet.Id && x.ClockOutTime == null);
                }
            }
            
            bool clockedIn = clockIn != null;

            var viewModel = new ClockInViewModel
            {
                UserId = user.Id,
                UserName = user.FirstName + " " + user.LastName,
                TimeSheetId = timeSheet.Id,
                CurrentlyClockedIn = clockedIn
            };

            ViewBag.Info = "Hello World";

            return View(viewModel);
        }

        //If In is true, clocking in, if In is false clocking out
        [HttpPost]
        public IActionResult ClockIn(bool In, ClockInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.CurrentlyClockedIn && In)
                {
                    ViewData["Info"] = "Currently Clocked In, clock out";
                    return View(model);
                }

                if (!model.CurrentlyClockedIn && In)
                {
                    var clockIn = new ClockIn
                    {
                        ClockInTime = DateTime.Now,
                        TimeSheetId = model.TimeSheetId
                    };

                    _context.ClockIns.Add(clockIn);
                    _context.SaveChanges();

                    return RedirectToAction("Index", new {In = true, Time = clockIn.ClockInTime});
                }

                if (model.CurrentlyClockedIn && !In)
                {
                    var clockIn = _context.ClockIns.Last(x => x.TimeSheetId == model.TimeSheetId && x.ClockOutTime == null);
                    clockIn.ClockOutTime = DateTime.Now;
                    _context.ClockIns.Update(clockIn);
                    _context.SaveChanges();

                    return RedirectToAction("Index", new { In = false, Time = clockIn.ClockOutTime });
                }
            }

            ViewData["Info"] = "We hit here for some reason";
            return View(model);
        }

        //Will return the timesheet for this week, or create it then return it if one does not exist yet
        private TimeSheet FindTimeSheet(string user)
        {
            var today = DateTime.Now;
            DateTime.Today.StartOfWeek(Startoftimesheet);
            TimeSheet timesheet;

            if (_context.TimeSheets.Any(x => x.UserId == user))
            {
                timesheet = _context.TimeSheets
                .First(x => x.UserId == user && x.StartDate <= today && x.EndDate >= today);

            }
            else
            {
                timesheet = CreateTimeSheet(user);
            }

            return timesheet;
        }

        //Creates a timesheet in the span 
        private TimeSheet CreateTimeSheet(string user)
        {
            var timesheet = new TimeSheet();
            var userRecord = _userManager.FindByIdAsync(user);

            timesheet.UserId = user;
            timesheet.StartDate = DateTime.Today.StartOfWeek(Startoftimesheet);
            timesheet.EndDate = timesheet.StartDate.AddDays(Endoftimsheet);
            timesheet.ExemptFromOvertime = userRecord.Result.ExemptFromOvertime;

            //need to call save changes
            _context.TimeSheets.Add(timesheet);
            _context.SaveChanges();

            return timesheet;
        }
    }
}