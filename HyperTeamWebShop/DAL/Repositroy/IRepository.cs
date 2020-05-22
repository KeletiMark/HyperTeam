using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.Repositroy
{
    public interface IRepository<TEntity> where TEntity :class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        int Insert(TEntity entity);
        int Update(TEntity entity);
        void Delete(int id);
        void Archive(int id);
        void Restore(int id);
    }
}
