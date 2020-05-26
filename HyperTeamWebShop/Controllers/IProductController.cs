using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.Controllers
{
    interface IProductController<TDto> where TDto : class
    {
        public ActionResult<IEnumerable<TDto>> GetAll();
        public ActionResult<TDto> GetById(int id);
        public ActionResult<int> Insert(TDto dto);
        public ActionResult<int> Update(TDto dto);
        public ActionResult Delete(int id);
    }
}
