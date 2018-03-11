using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TimeClock.Models.Entities.Base;

namespace TimeClock.Models.Entities
{
    [Table("ClockIns", Schema = "Clock")]
    public class ClockIn : EntityBase
    {
        //Set this by default
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ClockInTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ClockOutTime {get; set;}

        //Start navigation props

        public int TimeSheetId { get; set; }

        [ForeignKey(nameof(TimeSheetId))]
        public TimeSheet TimeSheet { get; set; }
    }
}
