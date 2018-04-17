using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeClock.Models.Entities
{
    [Table("Employees", Schema="Clock")]
    public class Employee : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        //Default to true
        public bool Active { get; set; }

        //If Exempt then true
        [Required]
        public bool Exempt { get; set; }

        [InverseProperty(nameof(Wage.Employee))]
        public List<Wage> Wages { get; set; }

        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        //Start Navigation and keys

        public string SupervisorId { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        public Employee Supervisor { get; set; }

        [InverseProperty(nameof(Supervisor))]
        public List<Employee> Supervising { get; set; }

        [InverseProperty(nameof(Approval.Supervisor))]
        public List<Approval> Approvals { get; set; }

        [InverseProperty(nameof(Vacation.Employee))]
        public List<Vacation> Vacations { get; set; }

        [InverseProperty(nameof(TimeSheet.Employee))]
        public List<TimeSheet> TimeSheets { get; set; }
    }
}
