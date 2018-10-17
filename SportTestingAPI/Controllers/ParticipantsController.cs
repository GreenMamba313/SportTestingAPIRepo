using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestingAPI.Repository;
using SportTestingAPI.BasicAuthentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace SportTestingAPI.Controllers
{
    [BasicAuthorize("sporttesting.com")]
    [Produces("application/json")]
    [Route("api/Participants")]
    public class ParticipantsController : Controller
    {
        private readonly ILogger logger;

        private readonly IParticipantsRepository repository;
 

        public ParticipantsController(IParticipantsRepository repository, ILogger<ParticipantsController> logger)
        {
            this.repository = repository;
            this.logger = logger;

        }

        private String ValidateInput(Models.Participants model)
        {
            String Error = "";

            if (model == null)
            {
                Error = "Please provide a data.";
                return Error;
            }

            if (model.combine_id is null || model.combine_id == 0)
            {
                Error += "\ncombine id is required field";
            }

            if (model.user_id is null || model.user_id == 0)
            {
                Error += "\nUser id is required field";
            }




            return Error;

        }

        // POST api/Participants
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Participants model)
        {

            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);


            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetParticipantByID", new { id = entity.id }, entity);

        }

        [HttpPut("{id}", Name = "PutParticipantByID")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Participants model)
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

            entity.id =  id;
            entity.combine_id = model.combine_id;
            entity.user_id = model.user_id;
            entity.participant_type = model.participant_type;
            entity.band_id = model.band_id;
            entity.rfid = model.rfid;
            entity.preemail = model.preemail;
            entity.postemail = model.postemail;
            entity.created = model.created;
            entity.modified = DateTime.Now;
            

            await repository.UpdateAsync(entity);


            return Ok("data has been modified");
        }


        [HttpGet("{id}", Name = "GetParticipantByID")]
        public async Task<IActionResult> Get(long id)
        {
            logger.LogInformation("calling get participants by  id");
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }


        [HttpGet]
        [Route("GetParticipantByUserID/{userid}")]
        public async Task<IActionResult> GetParticipantByUserID(long userid)
        {

   
            var item = await repository.FindAsyncByUserID(userid);
  


            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetParticipantByCombineID/{combineid}")]
        public IActionResult GetParticipantByCombineID(long combineid)
        {


            var item =  repository.FindAsyncByCombineID(combineid);



            if (item == null)
                return NotFound();

            return Ok(item);




        }


        [HttpGet]
        [Route("GetParticipantByBandID/{bandid}")]
        public async Task<IActionResult> GetParticipantByCombineID(string bandid)
        {


            var item = await repository.FindAsyncByBandID(bandid);



            if (item == null)
                return NotFound();

            return Ok(item);




        }
    }
}