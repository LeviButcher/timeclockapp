﻿using System;
using System.Collections.Generic;
using System.Text;
using TimeClock.Models.Entities.Base;

//Class taken from Building Web Applications with Visual Studio 2017
namespace TimeClock.DAL.Repos.Base
{
    public interface IRepo<T> where T : EntityBase
    {
        int Count { get; }
        bool HasChanges { get; }
        T Find(int? id);
        T GetFirst();
        IEnumerable<T> GetAll();
        IEnumerable<T> GetRange(int skip, int take);
        int Add(T entity, bool persist = true);
        int AddRange(IEnumerable<T> entities, bool persist = true);
        int Update(T entity, bool persist = true);
        int UpdateRange(IEnumerable<T> entities, bool persist = true);
        int Delete(T entity, bool persist = true);
        int DeleteRange(IEnumerable<T> entities, bool persist = true);
        int Delete(int id, byte[] timeStamp, bool persist = true);
        int SaveChanges();
    }
}
