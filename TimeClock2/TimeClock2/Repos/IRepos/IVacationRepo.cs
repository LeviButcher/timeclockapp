using System.Collections.Generic;
using TimeClock2.Models;

namespace TimeClock2.Repos.IRepos
{
    public interface IVacationRepo
    {
        IEnumerable<Vacation> GetAll();

        Vacation Find(int id);

        int Add(Vacation vacation);

        int Update(Vacation vacation);

    }
}
