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
    [Route("api/Drilldata")]
    public class DrilldataController : Controller
    {
        private readonly IDrill_dataRepository repository;
        public DrilldataController(IDrill_dataRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Drill_data model)
        {
            String Error = "";

            if (model == null)
            {
                Error = "Please provide a data.";
                return Error;
            }

            if (model.combine_id is null || model.combine_id == 0)
            {
                Error += "\nUser combine id is required field";
            }

            if (model.drill_id is null || model.drill_id == 0)
            {
                Error += "\nDrill id is required field";
            }

            if (model.user_id is null || model.user_id == 0)
            {
                Error += "\nUser id is required field";
            }

            if (model.athlete_age is null || model.athlete_age == 0)
            {
                Error += "\nAthelete age is required field";
            }

            if (model.is_certified is null )
            {
                Error += "\nIs certified is required field";
            }
            if (model.is_comparable is null)
            {
                Error += "\nIs comparable is required field";
            }

            if (model.dq_flag is null)
            {
                Error += "\nDq flag is required field";
            }

            return Error;

        }


        // POST api/Drilldata
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Drill_data model)
        {

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetDrilldataByID", new { id = entity.id }, entity);

        }
        
        // PUT api/Drilldata/5
        [HttpPut("{id}", Name = "PutDrilldataByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Drill_data model)
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
            entity.drill_id = model.drill_id;
            entity.sport_id = model.sport_id;
            entity.capture_system = model.capture_system;
            entity.capture_id = model.capture_id;
            entity.user_id = model.user_id;
            entity.athlete_age = model.athlete_age;
            entity.attempt = model.attempt;
            entity.total = model.total;
            entity.result_1 = model.result_1;
            entity.result_2 = model.result_2;
            entity.result_3 = model.result_3;
            entity.result_4 = model.result_4;
            entity.result_5 = model.result_5;
            entity.result_6 = model.result_6;
            entity.result_7 = model.result_7;
            entity.result_8 = model.result_8;
            entity.result_9 = model.result_9;
            entity.dir_1 = model.dir_1;
            entity.is_certified = model.is_certified;
            entity.is_comparable = model.is_comparable;
            entity.dq_flag = model.dq_flag;
            entity.test_date = model.test_date;
            entity.verified = model.verified;
            entity.capture_time = model.capture_time;
            entity.created = model.created;
            entity.modified = model.modified;

            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }


        [HttpGet("{id}", Name = "GetDrilldataByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }

        [HttpGet]
        [Route("GetDrillDataByUserID/{userid}")]
        public async Task<IActionResult> GetDrillDataByUserID(long userid)
        {


            var item = await repository.FindAsyncByUserID(userid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetDrillDataBySportID/{sportid}")]
        public async Task<IActionResult> GetDrillDataBySportID(long sportid)
        {


            var item = await repository.FindAsyncBySportID(sportid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetDrillDataByDrillID/{drillid}")]
        public async Task<IActionResult> GetDrillDataByDrillID(long drillid)
        {


            var item = await repository.FindAsyncByDrillID(drillid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetDrillDataByCombineID/{combineid}")]
        public async Task<IActionResult> GetDrillDataByCombineID(long combineid)
        {


            var item = await repository.FindAsyncByCombineID(combineid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

    }
}