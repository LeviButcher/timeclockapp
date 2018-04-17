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
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        //For Overtime
        [Required]
        public bool Exempt { get; set; }


        [NotMapped]
        [DataType(DataType.Currency)]
        public double TotalPay;
        //Start navigation props
        [Required]
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        [InverseProperty(nameof(ClockIn.TimeSheet))]
        public List<ClockIn> ClockIns { get; set; }


        public int? ApprovalId { get; set; }

        [ForeignKey(nameof(ApprovalId))]
        public Approval Approval { get; set; }

    }
}
