using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using TimeClock4.Entity;

namespace TimeClock4.ViewModels.TimeSheetViewModels
{
    public class SupervisorDetailTimeSheetViewModel
    {
        [Required]
        [HiddenInput]
        public int TimesheetId { get; set; }

        public string User { get; set; }

        [Required]
        [Display(Name = "Approval")]
        public ApprovalType Approved { get; set; }

        [Display(Name = "Reason Denied")]
        public string ReasonDenied { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Exempt From Overtime")]
        public bool ExemptFromOvertime { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Amount Made")]
        public double AmountMade { get; set; }

        [Display(Name = "Time Worked (Hourly)")]
        public double TimeWorked { get; set; }
    }
}
