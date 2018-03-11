using System;
using System.Collections.Generic;
using System.Text;
using TimeClock.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeClock.Models.Entities
{
    [Table("TimeSheets", Schema = "Clock")]
    public class TimeSheet : EntityBase
    {

        public bool? Approved { get; set; }

        [DataType(DataType.MultilineText)]
        public string ReasonDenied { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        //Start navigation props

        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [InverseProperty(nameof(ClockIn.TimeSheet))]
        public List<ClockIn> ClockIns { get; set; }
    }
}
