using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TimeClock2.Data;
using TimeClock2.Models;
using TimeClock2.Repos.IRepos;

namespace TimeClock2.Repos
{
    public class VacationRepo : IVacationRepo
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<Vacation> _vacations;

        public VacationRepo(DbContextOptions<ApplicationDbContext> options)
        {
            _db = new ApplicationDbContext(options);
            _vacations = _db.Vacations;
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacations;
        }

        public Vacation Find(int id)
        {
            return _db.Vacations.Find(id);
        }

        public int Add(Vacation vacation)
        {
            _vacations.Add(vacation);
            return _db.SaveChanges();
        }

        public int Update(Vacation vacation)
        {
            _vacations.Update(vacation);
            return _db.SaveChanges();
        }
    }
}
