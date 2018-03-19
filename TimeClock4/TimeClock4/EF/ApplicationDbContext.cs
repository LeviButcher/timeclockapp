﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeClock4.Entity;

namespace TimeClock4.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<ClockIn> ClockIns { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TimeClock4;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Vacation>()
                .Property(e => e.DateCreated)
                .HasColumnType("date")
                .HasDefaultValueSql("getdate()");

            builder.Entity<Vacation>()
                .Property(e => e.StartDate)
                .HasColumnType("date");

            builder.Entity<Vacation>()
                .Property(e => e.EndDate)
                .HasColumnType("date");

        }
    }
}
