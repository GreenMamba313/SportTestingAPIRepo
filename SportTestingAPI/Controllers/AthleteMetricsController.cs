using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestingAPI.Repository;
using SportTestingAPI.BasicAuthentication;
namespace SportTestingAPI.Controllers
{
    [BasicAuthorize("sporttesting.com")]
    [Produces("application/json")]
    [Route("api/AthleteMetrics")]
    public class AthleteMetricsController : Controller
    {
        private readonly IAthlete_metricsRepository repository;
        public AthleteMetricsController(IAthlete_metricsRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Athlete_metrics model)
        {
            String Error = "";

            if (model == null)
            {
                Error = "Please provide a data.";
                return Error;

            }

            if (String.IsNullOrEmpty(model.name) || String.IsNullOrEmpty(model.name.Trim()))
            {
                Error += "\n name is required field";
            }

            if (String.IsNullOrEmpty(model.format) || String.IsNullOrEmpty(model.format.Trim()))
            {
                Error += "\n format name is required field";
            }

            if (model.active == null)
            {
                Error += "\n status is required field";
            }

            return Error;

        }


        // POST api/AthleteMetrics
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Athlete_metrics model)
        {

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("Get_athlete_metricsByID", new { id = entity.id }, entity);

        }

        // PUT api/AthleteMetrics/5
        [HttpPut("{id}", Name = "Put_athlete_metricsByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Athlete_metrics model)
        {
            if (id == 0)
                return BadRequest("id is required field");

            String Error = ValidateInput(model);
            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);

            var entity = await repository.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.id = id;
            entity.name = model.name;
            entity.format = model.format;
            entity.active = model.active;
            entity.created = model.created;
            entity.modified =DateTime.Now;

            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }

        [HttpGet("{id}", Name = "Get_athlete_metricsByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }



    }
}