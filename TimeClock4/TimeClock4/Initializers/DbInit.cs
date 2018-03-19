using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TimeClock4.EF;
using TimeClock4.Entity;

namespace TimeClock4.Initializers
{
    //Idea of class comes from ->https://gist.github.com/mombrea/9a49716841254ab1d2dabd49144ec092
    public class DbInit : IDbInit
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInit(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //This example just creates an Administrator role and one Admin users
        public void Initialize()
        {
            //create database schema if none exists
            _context.Database.Migrate();

            //ADMIN
            //If there is already an Administrator role, abort
            if (!_context.Roles.Any(r => r.Name == "Administrator"))
            {
                //Create the Administartor Role
                _roleManager.CreateAsync(new IdentityRole("Administrator")).GetAwaiter().GetResult();
            }

            if (!_context.Roles.Any(r => r.Name == "BasicUser"))
            {
                //Create the Administartor Role
                _roleManager.CreateAsync(new IdentityRole("BasicUser")).GetAwaiter().GetResult();
            }

            //SUPERVISOR
            //If there is already an Supervisor role, abort
            if (!_context.Roles.Any(r => r.Name == "Supervisor"))
            {
                //Create the Administartor Role
                _roleManager.CreateAsync(new IdentityRole("Supervisor")).GetAwaiter().GetResult();
            }

            if (!_context.Roles.Any(r => r.Name == "Payroll"))
            {
                //Create the Administartor Role
                _roleManager.CreateAsync(new IdentityRole("Payroll")).GetAwaiter().GetResult();
            }


            var result = _userManager.FindByNameAsync("admin@develop.com").GetAwaiter().GetResult();

            if (result == null)
            {
                //Create the default Admin account and apply the Administrator role
                string user = "admin@develop.com";
                string password = "Develop@90";
                string firstName = "Bob";
                string lastName = "Bobby";
                _userManager.CreateAsync(new ApplicationUser { UserName = user, Email = user, EmailConfirmed = true, FirstName = firstName, LastName = lastName }, password).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync(user).GetAwaiter().GetResult(), "Administrator").GetAwaiter().GetResult();
            }

            result = _userManager.FindByNameAsync("user1@develop.com").GetAwaiter().GetResult();

            if (result == null)
            {
                //Create the default Supervisor account and apply the Administrator role
                string user = "user1@develop.com";
                string password = "Develop@90";
                string firstName = "Tom";
                string lastName = "Tommy";
                _userManager.CreateAsync(new ApplicationUser { UserName = user, Email = user, EmailConfirmed = true, FirstName = firstName, LastName = lastName }, password).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync(user).GetAwaiter().GetResult(), "Supervisor").GetAwaiter().GetResult();
            }

        }
    }
}
