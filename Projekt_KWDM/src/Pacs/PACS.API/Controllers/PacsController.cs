using Microsoft.AspNetCore.Mvc;
using PACS.API.Data.Interfaces;
using PACS.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PACS.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PacsController : ControllerBase
    {

        private ICommanderPACS _repository;
        public PacsController(ICommanderPACS _repository)
        {
            this._repository = _repository;
        }

        [HttpGet]
        public ActionResult TestApi()
        {
            
                return Ok("Hello PACS");
        }

        [HttpPost]
        [Route("Image")]
        public ActionResult Image(ImageInfo seriesModel)
        {
            byte[] data = _repository.TakeImage(seriesModel);
            if (data != null)
                return Ok(data);
            else
                return NotFound();
        }

    }
}
