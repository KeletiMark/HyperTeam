using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HyperTeamWebShop.BLL;
using HyperTeamWebShop.DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HyperTeamWebShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemoryController : ControllerBase, IProductController<MemoryDTO>
    {
        private readonly IService<MemoryDTO> memoryService;

        public MemoryController(IService<MemoryDTO> memoryService) 
        {
            this.memoryService = memoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MemoryDTO>> GetAll()
        {
            try
            {
                return Ok(memoryService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<MemoryDTO> GetById(int id)
        {
            try
            {
                return Ok(memoryService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<int> Insert(MemoryDTO memory)
        {
            try
            {
                memoryService.Insert(memory);
                return Ok(memory.Id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public ActionResult<int> Update(MemoryDTO memory)
        {
            try
            {
                memoryService.Update(memory);
                return Ok(memory.Id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                memoryService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}