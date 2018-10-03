using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.Merrid.ProjectX.WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuresController : ControllerBase
    {
        private readonly IMeasuresService _measuresService;

        public MeasuresController(IMeasuresService measuresService)
        {
            _measuresService = measuresService;
        }


        [HttpGet]
        public IActionResult Get() => Ok(_measuresService.Get());


        [HttpGet("{id}", Name = "GetMeasureLink")]
        public IActionResult Get(int id)
        {
            var measure = _measuresService.Get(id);

            if (measure == null)
                return NotFound();

            return Ok(measure);
        }


        [HttpGet("~/api/meters/{meterId}/measures")]
        public IActionResult GetByMeter(int meterId)
        {
            var measures = _measuresService.GetByMeter(meterId);

            return Ok(measures);
        }

        [HttpPost]
        public IActionResult Post(Measure measure)
        {
            _measuresService.Add(measure);

            return CreatedAtRoute("GetMeasureLink", new { id = measure.Id }, measure);
        }
    }
}
