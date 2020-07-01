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
    public class ProcessorController : ControllerBase, IProductController<ProcessorDTO>
    {
        private readonly IService<ProcessorDTO> processorService;

        public ProcessorController(IService<ProcessorDTO> processorService)
        {
            this.processorService = processorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProcessorDTO>> GetAll()
        {
            try
            {
                return Ok(processorService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProcessorDTO> GetById(int id) 
        {
            try
            {
                return Ok(processorService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<int> Insert(ProcessorDTO processor)
        {
            try
            {
                processorService.Insert(processor);
                return Ok(processor.Id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public ActionResult<int> Update(ProcessorDTO processor)
        {
            try
            {
                processorService.Update(processor);
                return Ok(processor.Id);
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
                processorService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}