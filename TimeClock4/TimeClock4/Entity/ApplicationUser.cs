using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeClock4.Entity
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [InverseProperty(nameof(Vacation.User))]
        public List<Vacation> Vacations { get; set; }

    }
}
