using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeClock4.Entity.Base;

namespace TimeClock4.Entity
{
    public class ClockIn : EntityBase
    {
        [Required]
        public DateTime ClockInTime { get; set; }

        public DateTime? ClockOutTime { get; set; }

        [Required]
        public int TimeSheetId { get; set; }

        //Navigation Props

        [ForeignKey(nameof(TimeSheetId))]
        public TimeSheet TimeSheet { get; set; }

    }
}
