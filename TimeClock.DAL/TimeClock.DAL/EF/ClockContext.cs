using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeClock.Models.Entities;

namespace TimeClock.DAL.EF
{
    public class ClockContext : IdentityDbContext<Employee>
    {
        public ClockContext()
        {

        }

        public ClockContext(DbContextOptions options) : base(options)
        {

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

            //Set Active Default Value
            builder.Entity<Employee>()
                .Property(e => e.Active)
                .HasDefaultValue(true);

            builder.Entity<Vacation>()
                .Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }

        DbSet<Employee> Employees { get; set; }
        DbSet<Vacation> Vacations { get; set; }

    }
}
