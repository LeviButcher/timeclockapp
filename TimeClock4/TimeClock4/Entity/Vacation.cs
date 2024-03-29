﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimeClock4.Entity.Base;

namespace TimeClock4.Entity
{
    public class Vacation : EntityBase
    {
        [Required] [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required] [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Reason { get; set; }

        [Required]
        public string UserId { get; set; }

        //Start Navigation and keys

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        [Required]
        [DefaultValue(ApprovalType.Waiting)]
        public ApprovalType Approval { get; set; }
    }
}
