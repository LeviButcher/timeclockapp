using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Pages
{
    public class HomeModel : PageModel
    {
        private readonly OdeToFoodDbContext _context;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public HomeModel(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Restaurants = _context.Restaurants;
        }
    }
}