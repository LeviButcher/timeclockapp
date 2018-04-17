using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TimeClock.Models.Entities.Base;

namespace TimeClock.Models.Entities
{
    [Table("Approvals", Schema = "Clock")]
    public class Approval : EntityBase
    {
        [Required]
        public string SupervisorId { get; set; }

        public Employee Supervisor { get; set; }

        [Required]
        public bool Approved { get; set; }

        //Nullable
        [MaxLength(250)]
        public string AdditionalComments { get; set; }

        //Inverse Props
        [InverseProperty(nameof(Vacation.Approval))]
        public Vacation VacationApproval { get; set; }
    }
}
