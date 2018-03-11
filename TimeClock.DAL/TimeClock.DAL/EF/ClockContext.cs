using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TimeClock.Models.Entities;

namespace TimeClock.DAL.EF
{
    public class ClockContext : IdentityDbContext<Employee, IdentityRole, string>
    {
        public ClockContext()
        {

        }

        public ClockContext(DbContextOptions options) : base(options)
        {
            try
            {
                Database.Migrate();
            }
            catch(Exception)
            {
                //Do something here
            }
            
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TimeClock;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Fluent API Here
            base.OnModelCreating(builder);

            //Set Active Default Value
            builder.Entity<Employee>()
                .Property(e => e.Active)
                .HasDefaultValue(true);

            builder.Entity<Vacation>()
                .Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Entity<TimeSheet>()
                .Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder.Entity<ClockIn>()
                .Property(e => e.ClockInTime)
                .HasDefaultValueSql("getdate()");

        }

        DbSet<Employee> Employees { get; set; }
        DbSet<Vacation> Vacations { get; set; }
        DbSet<TimeSheet> TimeSheets { get; set; }
        DbSet<ClockIn> ClockIns { get; set; }
    }
}
