using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace TimeClock4.ViewModels.TimeSheetViewModels
{
    public class GroupWeekReportViewModel
    {
        [HiddenInput]
        public string SupervisorId { get; set; }

        public string Supervisor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public double TotalEarning { get; set; }
    }
}
