using System;
using System.ComponentModel.DataAnnotations;

namespace TimeClock2.ViewModels
{
    public class VacationViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
