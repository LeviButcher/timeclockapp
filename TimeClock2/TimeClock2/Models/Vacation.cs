using System;
using System.ComponentModel.DataAnnotations;
using TimeClock2.Models.Base;

namespace TimeClock2.Models
{
    public class Vacation : ModelBase
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        //Start Navigation and keys

    }
}
