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
    [Route("api/CombineAthleteMetrics")]
    public class CombineAthleteMetricsController : Controller
    {
        private readonly ICombine_athlete_metricsRepository repository;
        public CombineAthleteMetricsController(ICombine_athlete_metricsRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Combine_athlete_metrics model)
        {
            String Error = "";

            if (model == null)
            {
                Error = "Please provide a data.";
                return Error;

            }

            if (model.combine_id is null || model.combine_id == 0)
            {
                Error += "\n combine id is required field";
            }

            if (model.athlete_metric_id is null || model.athlete_metric_id == 0)
            {
                Error += "\n athlete metric id is required field";
            }

            if (model.allow_coach_report == null)
            {
                Error += "\n allow coach report is required field";
            }

            if (model.allow_athlete_report == null)
            {
                Error += "\n allow athlete report is required field";
            }

            return Error;

        }

        // POST api/CombineAthleteMetrics
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Combine_athlete_metrics model)
        {

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetCombine_athlete_metricsByID", new { id = entity.id }, entity);

        }

        

        // PUT api/CombineAthleteMetrics/5
        [HttpPut("{id}", Name = "PutCombine_athlete_metricsByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Combine_athlete_metrics model)
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
            entity.combine_id = model.combine_id;
            entity.athlete_metric_id = model.athlete_metric_id;
            entity.allow_coach_report = model.allow_coach_report;
            entity.allow_athlete_report = model.allow_athlete_report;



            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }

        [HttpGet("{id}", Name = "GetCombine_athlete_metricsByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }

        [HttpGet]
        [Route("GetCombineAthleteMetricsByCombineID/{combineid}")]
        public async Task<IActionResult> GetCombineAthleteMetricsByCombineID(long combineid)
        {


            var item = await repository.FindAsyncByCombineID(combineid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetCombineAthleteMetricsByAthleteMetricID/{athletemetricid}")]
        public async Task<IActionResult> GetCombineAthleteMetricsByAthleteMetricID(long athletemetricid)
        {
            var item = await repository.FindAsyncByAthleteMetricID(athletemetricid);

            if (item == null)
                return NotFound();

            return Ok(item);
        }


    }
}