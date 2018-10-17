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
    [Route("api/CombineMetrics")]
    public class CombineMetricsController : Controller
    {

        private readonly ICombine_metricsRepository repository;
        public CombineMetricsController(ICombine_metricsRepository repository)
        {
            this.repository = repository;
        }


        private String ValidateInput(Models.Combine_metrics model)
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

            if (model.athlete_id is null || model.athlete_id == 0)
            {
                Error += "\n athlete  id is required field";
            }

            if (String.IsNullOrEmpty(model.value) || String.IsNullOrEmpty(model.value.Trim()))
            {
                Error += "\n value is required field";
            }




            return Error;

        }

        // POST api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Combine_metrics model)
        {

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetCombine_metricsByID", new { id = entity.id }, entity);

        }

        
        // PUT api/CombineMetrics/5
        [HttpPut("{id}", Name = "PuttCombine_metricsByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Combine_metrics model)
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
            entity.athlete_id = model.athlete_id;
            entity.value = model.value;
            entity.created = model.created;
            entity.modified = DateTime.Now;

            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }

        [HttpGet("{id}", Name = "GetCombine_metricsByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }

        [HttpGet]
        [Route("GetCombineMetricByCombineID/{combineid}")]
        public async Task<IActionResult> GetCombineMetricByCombineID(long combineid)
        {


            var item = await repository.FindAsyncByCombineID(combineid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }


        [HttpGet]
        [Route("GetCombineMetricByAthleteID/{athleteid}")]
        public async Task<IActionResult> GetCombineMetricByAthleteID(long athleteid)
        {


            var item = await repository.FindAsyncByAthleteID(athleteid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetCombineMetricByAthleteMetricID/{athletemetricid}")]
        public async Task<IActionResult> GetCombineMetricByAthleteMetricID(long athletemetricid)
        {
           var item = await repository.FindAsyncByAthleteMetricID(athletemetricid);

           if (item == null)
                return NotFound();

            return Ok(item);
        }


    }
}