using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.BLL
{
    public interface IService<TDto> where TDto : class
    {
        public IEnumerable<TDto> GetAll();
        public TDto GetById(int id);
        public int Insert(TDto dto);
        public int Update(TDto dto);
        public void Delete(int id);
    }
}
