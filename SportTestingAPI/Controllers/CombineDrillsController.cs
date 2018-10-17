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
    [Route("api/CombineDrills")]
    public class CombineDrillsController : Controller
    {

        private readonly ICombine_drillsRepository repository;
        public CombineDrillsController(ICombine_drillsRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Combine_drills model)
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

            if (model.drill_id is null || model.drill_id == 0)
            {
                Error += "\n drill id is required field";
            }

            if (model.display_order == null)
            {
                Error += "\n display order is required field";
            }

            if (model.display_group == null)
            {
                Error += "\n display group is required field";
            }

            return Error;

        }


        // POST api/CombineDrills
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Combine_drills model)
        {

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetCombine_drillsByID", new { id = entity.id }, entity);

        }
                       
        // PUT api/CombineDrills/5
        [HttpPut("{id}", Name = "PutCombine_drillsByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Combine_drills model)
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
            entity.display_order = model.display_order;
            entity.display_group = model.display_group;
            entity.lanes = model.lanes;

            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }

        [HttpGet("{id}", Name = "GetCombine_drillsByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }


        [HttpGet]
        [Route("GetCombineDrillsByDrillID/{drillid}")]
        public async Task<IActionResult> GetCombineDrillsByDrillID(long drillid)
        {


            var item = await repository.FindAsyncByDrillID(drillid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetCombineDrillsByCombineID/{combineid}")]
        public async Task<IActionResult> GetCombineDrillsByCombineID(long combineid)
        {


            var item = await repository.FindAsyncByCombineID(combineid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }






    }
}