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
    [Route("api/Sports")]
    public class SportsController : Controller
    {
        private readonly ISportsRepository repository;
        public SportsController(ISportsRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Sports model)
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

            if (String.IsNullOrEmpty(model.display_name) || String.IsNullOrEmpty(model.display_name.Trim()))
            {
                Error += "\n display name is required field";
            }

            if (model.status == null)
            {
                Error += "\n status is required field";
            }

            return Error;

        }

        // POST api/Sports
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Sports model)
        {

            String Error = ValidateInput( model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetSportByID", new { id = entity.id }, entity);

        }


        // PUT api/Sports/5
        [HttpPut("{id}" , Name = "PutSportByID")]
        public async Task<IActionResult> Put(long  id, [FromBody]Models.Sports model)
        {
            if (id == 0)
                return BadRequest("id is required field");

            String Error = ValidateInput( model);
            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);

            var entity = await repository.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.id = id;
            entity.name = model.name.Trim();
            entity.display_name = model.display_name.Trim();
            entity.status = model.status;
            await repository.UpdateAsync(entity);
     

            return Ok("data has been modified");
        }



        [HttpGet("{id}", Name = "GetSportByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }

    }
}