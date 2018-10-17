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
    [Route("api/Combines")]
    public class CombinesController : Controller
    {
        private readonly ICombinesRepository repository;
        public CombinesController(ICombinesRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Combines model)
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

            if (model.combine_id is null || model.combine_id == 0)
            {
                Error += "\n combine id is required field";
            }

            if (model.location_id is null || model.location_id == 0)
            {
                Error += "\nLocation id is required field";
            }

            if (model.admission_cost is null || model.admission_cost == 0)
            {
                Error += "\nAdmission cost is required field";
            }

            if (model.approved is null )
            {
                Error += "\nApproved is required field";
            }

            if (model.joinable is null || model.joinable == 0)
            {
                Error += "\nJoinable is required field";
            }

            if (String.IsNullOrEmpty(model.template_group) || String.IsNullOrEmpty(model.template_group.Trim()))
            {
                Error += "\n Template Group is required field";
            }

            if (model.allow_csv is null )
            {
                Error += "\nAllow CSV is required field";
            }

            if (model.allow_pdf is null)
            {
                Error += "\nAllow PDF is required field";
            }

            if (model.pdf_drill_group is null)
            {
                Error += "\nPDF drill group is required field";
            }

            if (model.separate_positions is null)
            {
                Error += "\nSeparate Positions is required field";
            }

            if (model.rankings is null)
            {
                Error += "\nRankings is required field";
            }

            if (model.tally is null)
            {
                Error += "\nTally is required field";
            }

            if (model.locked is null)
            {
                Error += "\nLocked is required field";
            }


            if (model.archived is null)
            {
                Error += "\nArchieved is required field";
            }
            if (model.hide_results is null)
            {
                Error += "\n Hide results is required field";
            }

            return Error;

        }


        // POST api/Combines
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Combines model)
        {

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetCombineByID", new { id = entity.id }, entity);

        }



        //
        // PUT api/Combines/5
        [HttpPut("{id}", Name = "PutCombineByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Combines model)
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
            entity.combine_id = model.combine_id;
            entity.location_id = model.location_id;
            entity.sport_id = model.sport_id;
            entity.combine_logo = model.combine_logo;
            entity.combine_date = model.combine_date;
            entity.description = model.description;
            entity.notes = model.notes;
            entity.admission_cost = model.admission_cost;
            entity.tax_amount = model.tax_amount;
            entity.age_restriction = model.age_restriction;
            entity.age_group_from = model.age_group_from;
            entity.age_group_to = model.age_group_to;
            entity.age_average = model.age_average;
            entity.approved = model.approved;
            entity.name = model.name;
            entity.joinable = model.joinable;
            entity.template_group = model.template_group;
            entity.allow_csv = model.allow_csv;
            entity.allow_pdf = model.allow_pdf;
            entity.allow_attempt = model.allow_attempt;
            entity.pdf_drill_group = model.pdf_drill_group;
            entity.separate_positions = model.separate_positions;
            entity.rankings = model.rankings;
            entity.tally = model.tally;
            entity.athlete_fields = model.athlete_fields;
            entity.order_field = model.order_field;
            entity.order_direction = model.order_direction;
            entity.aux_field_1_title = model.aux_field_1_title;
            entity.aux_field_2_title = model.aux_field_2_title;
            entity.required_positions = model.required_positions;
            entity.locked = model.locked;
            entity.archived = model.archived;
            entity.hide_results = model.hide_results;
            entity.coach_email_id = model.coach_email_id;
            entity.athlete_email_id = model.athlete_email_id;
            entity.access_code = model.access_code;
            entity.created = model.created;
            entity.modified = model.modified;

            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }


        [HttpGet("{id}", Name = "GetCombineByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }


        [HttpGet]
        [Route("GetCombineByUserID/{userid}")]
        public async Task<IActionResult> GetCombineByUserID(long userid)
        {


            var item = await repository.FindAsyncByUserID(userid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetCombineBySportID/{sportid}")]
        public async Task<IActionResult> GetCombineBySportID(long sportid)
        {


            var item = await repository.FindAsyncBySportID(sportid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

 
        [HttpGet]
        [Route("GetCombineByCombineID/{combineid}")]
        public async Task<IActionResult> GetCombineByCombineID(long combineid)
        {


            var item = await repository.FindAsyncByCombineID(combineid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }


        [HttpGet]
        [Route("GetCombineByLocationID/{locatonid}")]
        public async Task<IActionResult> GetCombineByLocationID(long locatonid)
        {


            var item = await repository.FindAsyncByLocationID(locatonid);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}