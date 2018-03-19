using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TimeClock4.ViewModels.ClockInViewModels
{
    public class ClockInViewModel
    {
        [HiddenInput]
        public string UserId { get; set; }

        [HiddenInput]
        public int TimeSheetId { get; set; }

        [Display(Name = "Welcome,")]
        public string UserName { get; set; }

        
        [Display(Name = "Currently Clocked In")]
        public bool CurrentlyClockedIn { get; set; }

        


    }
}
