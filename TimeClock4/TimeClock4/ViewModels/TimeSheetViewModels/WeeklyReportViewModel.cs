using System;
using System.ComponentModel.DataAnnotations;

namespace TimeClock4.ViewModels.TimeSheetViewModels
{
    public class WeeklyReportViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Company Wages Paid")]
        public double TotalEarning { get; set; }
    }
}
