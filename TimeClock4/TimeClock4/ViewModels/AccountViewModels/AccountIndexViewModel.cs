using System.Linq;
using TimeClock4.Entity;

namespace TimeClock4.ViewModels.AccountViewModels
{
    public class AccountIndexViewModel
    {
        public IQueryable<ApplicationUser> Users { get; set; }


    }
}
