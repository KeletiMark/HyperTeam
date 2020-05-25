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
    public class MotherboardController : ControllerBase, IProductController<MotherboardDTO>
    {
        private readonly IService<MotherboardDTO> motherboardService;

        public MotherboardController(IService<MotherboardDTO> motherboardService) 
        {
            this.motherboardService = motherboardService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MotherboardDTO>> GetAll()
        {
            try
            {
                return Ok(motherboardService.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<MotherboardDTO> GetById(int id)
        {
            try
            {
                return Ok(motherboardService.GetById(id));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<int> Insert(MotherboardDTO motherboard)
        {
            try
            {
                motherboardService.Insert(motherboard);
                return Ok(motherboard.Id);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public ActionResult<int> Update(MotherboardDTO motherboard)
        {
            try
            {
                motherboardService.Update(motherboard);
                return Ok(motherboard.Id);
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
                motherboardService.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}