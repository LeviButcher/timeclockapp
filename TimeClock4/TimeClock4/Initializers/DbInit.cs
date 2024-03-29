﻿using Microsoft.AspNetCore.Identity;
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

        public  async void SeedData()
        {
            var defaultPassword = "develop@90";

            //Create Default User
            ApplicationUser user1 = new ApplicationUser { FirstName = "Levi", LastName = "Butcher", Email = "Lbutt@develop.com", HourlyWage = 10.00, UserName = "Lbutt@develop.com" };
            await _userManager.CreateAsync(user1, defaultPassword);
            ApplicationUser user2 = new ApplicationUser { FirstName = "Bobby", LastName = "Tables", Email = "tables@develop.com", HourlyWage =  11.00, UserName = "tables@develop.com", Supervisor = user1 };
            await _userManager.CreateAsync(user2, defaultPassword);
            ApplicationUser user3 = new ApplicationUser { FirstName = "Sarah", LastName = "Sarahhaha", Email = "sarahhaha@develop.com", HourlyWage = 8.95, UserName = "sarahhaha@develop.com", Supervisor = user1 };
            await _userManager.CreateAsync(user3, defaultPassword);
            ApplicationUser user4 = new ApplicationUser { FirstName = "Rooky", LastName = "Rooky", Email = "rooky@develop.com", HourlyWage = 12.00, UserName = "rooky@develop.com", Supervisor = user1 };
            await _userManager.CreateAsync(user4, defaultPassword);

            //Add Users to Roles
            await _userManager.AddToRoleAsync(user1, "Supervisor");
            await _userManager.AddToRoleAsync(user2, "BasicUser");
            await _userManager.AddToRoleAsync(user3, "BasicUser");
            await _userManager.AddToRoleAsync(user4, "BasicUser");

            //user2 Timesheets
            

        }
    }
}
