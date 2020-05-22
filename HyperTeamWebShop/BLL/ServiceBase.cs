using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.BLL
{
    public abstract class ServiceBase<TDto> where TDto : class
    {
        public abstract IEnumerable<TDto> GetAll();
        public abstract TDto GetById(int id);
        public abstract int Insert(TDto dto);
        public abstract int Update(TDto dto);
        public abstract void Delete(int id);
    }
}
