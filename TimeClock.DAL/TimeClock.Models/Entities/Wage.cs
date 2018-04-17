using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TimeClock.Models.Entities.Base;

namespace TimeClock.Models.Entities
{
    [Table("Wages", Schema = "Clock")]
    public class Wage : EntityBase
    {
        [Required]
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double HourlyWage { get; set; }

        //nav props

        [InverseProperty(nameof(ClockIn.Wage))]
        public List<ClockIn> ClockIns { get; set; }
    }
}
