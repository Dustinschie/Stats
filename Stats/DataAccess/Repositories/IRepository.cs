using Stats.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stats.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        List<T> Get();
        T Get(int id);

        T Update(T obj);
        T Insert(T obj);

        int Delete(T obj);
    }
}