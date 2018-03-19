using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TimeClock4.Entity;

namespace TimeClock4.ViewModels.VacationViewModels
{
    public class DetailVacationViewModel
    {
        //Used for passing around the id
        public int Id { get; set; }

        [Required]
        [ReadOnly(true)]
        [Display(Name = "Requested By")]
        public string RequestBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ReadOnly(true)]
        public DateTime DateCreate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ReadOnly(true)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [ReadOnly(true)]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [ReadOnly(true)]
        public string Reason { get; set; }

        [DefaultValue(ApprovalType.Waiting)]
        [ReadOnly(true)]
        public ApprovalType Approval { get; set; }

        public string Supervisor { get; set; }
    }
}
