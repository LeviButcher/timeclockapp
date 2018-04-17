using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TimeClock.Models.Entities.Base;

namespace TimeClock.Models.Entities
{
    [Table("Vacations", Schema = "Clock")]
    public class Vacation : EntityBase
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [MaxLength(300)]
        public string Reasoning { get; set; }

        //Start Navigation and keys

        public int? ApprovalId { get; set; }

        [ForeignKey(nameof(ApprovalId))]
        public Approval Approval { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
