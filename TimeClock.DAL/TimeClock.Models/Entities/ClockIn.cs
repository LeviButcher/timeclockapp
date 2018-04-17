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
        public DateTime? ClockOutTime { get; set; }

        //Add Difference bettwen Clock out and clock in
        public double TimeClockedIn
        {
            get
            {
                //need to find a way to return this if possible
                if(ClockOutTime != null)
                {
                    TimeSpan timespent;
                    var start = ClockInTime;
                    var end = ClockOutTime;
                    timespent.Add(end - start);
                    return timespent.TotalMinutes;
                }
                return 0;
            }
        }

        //Add Amount earned for shift

        public double? AmountEarned => TimeClockedIn * Wage.HourlyWage;

        //Start navigation props

        public int TimeSheetId { get; set; }

        [ForeignKey(nameof(TimeSheetId))]
        public TimeSheet TimeSheet { get; set; }

        public int WageId { get; set; }

        [ForeignKey(nameof(WageId))]
        public Wage Wage {get;set;}
    }
}
