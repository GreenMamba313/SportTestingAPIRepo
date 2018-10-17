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
    [Route("api/Drills")]
    public class DrillsController : Controller
    {
        private readonly IDrillsRepository repository;
        public DrillsController(IDrillsRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Drills model)
        {
            String Error = "";

            if (model == null)
            {
                Error = "Please provide a data.";
                return Error;
            }

            if (model.user_id is null || model.user_id == 0)
            {
                Error += "\nUser id is required field";
            }

            if (model.sport_id is null || model.sport_id == 0)
            {
                Error += "\nSport id is required field";
            }

            if (String.IsNullOrEmpty(model.sport) || String.IsNullOrEmpty(model.sport.Trim()))
            {
                Error += "\n Sport is required field";
            }

            if (String.IsNullOrEmpty(model.input) || String.IsNullOrEmpty(model.input.Trim()))
            {
                Error += "\n Input name is required field";
            }

            if (model.checkpoints is null || model.checkpoints == 0)
            {
                Error += "\nCheck points is required field";
            }

            if (model.splits is null || model.splits == 0)
            {
                Error += "\nSplits is required field";
            }

            if (String.IsNullOrEmpty(model.splits_direction) || String.IsNullOrEmpty(model.splits_direction.Trim()))
            {
                Error += "\n Splits direction is required field";
            }

            if (String.IsNullOrEmpty(model.qualifier) || String.IsNullOrEmpty(model.qualifier.Trim()))
            {
                Error += "\n Qualifier is required field";
            }


            return Error;

        }

        // POST api/Drills
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Drills model)
        { 

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetDrillByID", new { id = entity.id }, entity);

        }


        // PUT api/Drills/5
        [HttpPut("{id}", Name = "PutDrillByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Drills model)
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
            entity.user_id = model.user_id;
            entity.drill_set = model.drill_set;
            entity.name = model.name;
            entity.display_name = model.display_name;
            entity.description = model.description;
            entity.sport = model.sport;
            entity.sport_id = model.sport_id;
            entity.input = model.input;
            entity.checkpoints = model.checkpoints;
            entity.splits = model.splits;
            entity.splits_direction = model.splits_direction;
            entity.qualifier = model.qualifier;
            entity.units = model.units;
            entity.max_total = model.max_total;
            entity.min_total = model.min_total;
            entity.display_order = model.display_order;
            entity.format = model.format;
            entity.archived = model.archived;
            entity.conversion_drill_id = model.conversion_drill_id;
            entity.download = model.download;
            entity.correlation_id = model.correlation_id;
            entity.created = model.created;
            entity.modified = model.modified;



            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }

        [HttpGet("{id}", Name = "GetDrillByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }

        [HttpGet]
        [Route("GetDrillByUserID/{userid}")]
        public async Task<IActionResult> GetDrillByUserID(long userid)
        {


            var item = await repository.FindAsyncByUserID(userid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetDrillBySportID/{sportid}")]
        public async Task<IActionResult> GetDrillBySportID(long sportid)
        {


            var item = await repository.FindAsyncBySportID(sportid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }


    }
}