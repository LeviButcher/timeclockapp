using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TimeClock4.Entity;

namespace TimeClock4.ViewModels.VacationViewModels
{
    public class CreateVacationViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }

        [DefaultValue(ApprovalType.Waiting)]
        public ApprovalType Approval { get; set; }

    }
}
