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
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        //Default to true
        public bool Active { get; set; }

        [Required]
        public bool Exempt { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float HourlyWage { get; set; }

        //Start Navigation and keys

        public List<Vacation> Vacations { get; set; }
    }
}
