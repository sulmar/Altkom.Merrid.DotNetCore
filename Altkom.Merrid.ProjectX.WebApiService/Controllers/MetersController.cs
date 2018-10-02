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
    public class MetersController : ControllerBase
    {
        private readonly IMetersService _metersService;

        public MetersController(IMetersService metersService)
        {
            _metersService = metersService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var meters = _metersService.Get();

            return Ok(meters);
        }

        [HttpGet("{id}", Name = "GetMeterLink")]
        public IActionResult Get(int id)
        {
            var meter = _metersService.Get(id);

            if (meter == null)
            {
                return NotFound();
            }

            return Ok(meter);
        }

        [HttpPost]
        public IActionResult Post(Meter meter)
        {
            _metersService.Add(meter);

            // zła praktyka
            // return Created($"https://localhost:44316/api/meters/{meter.Id}", meter);

            return CreatedAtRoute("GetMeterLink", new { id = meter.Id }, meter);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Meter meter)
        {
            if(id!=meter.Id)
            {
                return BadRequest();
            }


            // Komentarz
            _metersService.Update(meter);

            return Ok();
        }
    }
}
