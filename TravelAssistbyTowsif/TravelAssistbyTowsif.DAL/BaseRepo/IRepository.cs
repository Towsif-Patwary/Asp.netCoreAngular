using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAssistbyTowsif.DAL.BaseRepo
{
    public interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Remove(int id);
    }
    
}
