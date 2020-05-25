using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IIDentity
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        TEntity Get(int id);
        void Update(TEntity entity);
    }
}
