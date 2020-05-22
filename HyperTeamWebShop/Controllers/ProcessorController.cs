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
        private readonly ProcessorService processorService;

        public ProcessorController(ProcessorService processorService)
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}