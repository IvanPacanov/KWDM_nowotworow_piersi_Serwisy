using Microsoft.AspNetCore.Mvc;
using PACS.API.Data.Interfaces;
using PACS.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        //[HttpGet]
        //public ActionResult TestApi()
        //{            
        //        return Ok("Hello PACS");
        //}

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult Find()
        {
            var results = _repository.Find();
            if (results != null)
                return Ok(results);
            else
                return NotFound();
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DicomInfo), (int)HttpStatusCode.OK)]
        public ActionResult FindStudy([FromBody] DicomInfo imageInfo)
        {
            var results = _repository.FindStudy(imageInfo.id);
            if (results != null)
                return Ok(results);
            else
                return NotFound();
        }
        
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DicomInfo), (int)HttpStatusCode.OK)]
        public ActionResult FindSeries([FromBody] DicomInfo imageInfo)
        {
            var results = _repository.FindSeries(imageInfo.id, imageInfo.studyInstanceUID);
            if (results != null)
                return Ok(results);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(DicomInfo), (int)HttpStatusCode.OK)]
        public ActionResult FindInstances([FromBody] DicomInfo imageInfo)
        {
            var results = _repository.FindInstances(imageInfo.id, imageInfo.studyInstanceUID, imageInfo.seriesInstanceUID);
            if (results != null)
                return Ok(results);
            else
                return NotFound();
        }


        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TextInfo), (int)HttpStatusCode.OK)]
        public ActionResult Move([FromBody] DicomInfo imageInfo)
        {
            var results = _repository.Move(imageInfo.id, imageInfo.studyInstanceUID, imageInfo.seriesInstanceUID, imageInfo.SOPInstanceUID);
            if (results != null)
                return Ok(results);
            else
                return NotFound();
        }


        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TextInfo), (int)HttpStatusCode.OK)]
        public ActionResult SaveToFile(TextInfo text)
        {
            text.text = text.text.Replace("123#$!", "\n \n");
            var results = _repository.SaveToFile(text.text, text.name);
            if (results)
                return Ok(results);
            else
                return NotFound();
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult TakeFile(TextInfo text)
        {
            var results = _repository.TakeFile(text.name);
            if (results != null)
                return Ok(results);
            else
                return NotFound();
        }



    }
}
