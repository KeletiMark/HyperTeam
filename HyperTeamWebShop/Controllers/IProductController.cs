using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.Controllers
{
    interface IProductController<TDto> where TDto : class
    {
        public abstract ActionResult<IEnumerable<TDto>> GetAll();
        public abstract ActionResult<TDto> GetById(int id);
        public abstract ActionResult<int> Insert(TDto dto);
        public abstract ActionResult<int> Update(TDto dto);
        public abstract ActionResult Delete(int id);
    }
}
