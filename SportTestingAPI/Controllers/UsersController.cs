using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestingAPI.BasicAuthentication;
using SportTestingAPI.Repository;

namespace SportTestingAPI.Controllers
{
    [BasicAuthorize("sporttesting.com")]
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository repository;
        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        private String ValidateInput(Models.Users model)
        {
            String Error = "";

            if (model == null)
            {
                Error = "Please provide a data.";
                return Error;
            }

            if (model.user_id is null || model.user_id==0)
            {
                Error += "\nUser id is required field";
            }

            if (model.parent_user_id is null || model.parent_user_id == 0)
            {
                Error += "\nParent User id is required field";
            }
            if (model.organization_id is null || model.organization_id == 0)
            {
                Error += "\nOrganization id is required field";
            }

            if (String.IsNullOrEmpty(model.first_name) || String.IsNullOrEmpty(model.first_name.Trim()))
            {
                Error += "\nFirst name is required field";
            }

            if (String.IsNullOrEmpty(model.last_name) || String.IsNullOrEmpty(model.last_name.Trim()))
            {
                Error += "\nLast name is required field";
            }
            if (String.IsNullOrEmpty(model.email) || String.IsNullOrEmpty(model.email.Trim()))
            {
                Error += "\nEmail is required field";
            }

            if (model.role_id is null || model.role_id == 0)
            {
                Error += "\nRole id is required field";
            }

            if (model.newsletter is null || model.newsletter == 0)
            {
                Error += "\nNews letter is required field";
            }
            if (model.welcome is null || model.welcome == 0)
            {
                Error += "\nWelcome  is required field";
            }

            if (model.language_id is null || model.language_id == 0)
            {
                Error += "\nLanguage id  is required field";
            }

            return Error;

        }


        // POST api/Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Models.Users model)
        {
            String Error = ValidateInput(model);

            if (!String.IsNullOrEmpty(Error))
                return BadRequest(Error);

            var entity = await repository.AddAsync(model);


            return CreatedAtRoute("GetUserByID", new { id = entity.id }, entity);

        }


        // PUT api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Models.Users model)
        {
            if (id==0)
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
            entity.parent_user_id = model.parent_user_id;
            entity.organization_id = model.organization_id;
            entity.master_id = model.master_id;
            entity.first_name = model.first_name;
            entity.last_name = model.last_name;
            entity.username = model.username;
            entity.email = model.email;
            entity.password = model.password;
            entity.activation_code = model.activation_code;
            entity.share_key = model.share_key;
            entity.role_id = model.role_id;
            entity.status_id = model.status_id;
            entity.created_ip = model.created_ip;
            entity.newsletter = model.newsletter;
            entity.welcome = model.welcome;
            entity.aux2 = model.aux2;
            entity.language_id = model.language_id;
            entity.address1 = model.address1;
            entity.address2 = model.address2;
            entity.city_id = model.city_id;
            entity.province_id = model.province_id;
            entity.country_id = model.country_id;
            entity.postal_code = model.postal_code;
            entity.primary_phone = model.primary_phone;
            entity.cell_phone = model.cell_phone;
            entity.profile_picture = model.profile_picture;
            entity.account_level_id = model.account_level_id;
            entity.title = model.title;
            entity.organization = model.organization;
            entity.support_email = model.support_email;
            entity.dob = model.dob;
            entity.height = model.height;
            entity.weight = model.weight;
            entity.shot = model.shot;
            entity.catches = model.catches;
            entity.position = model.position;
            entity.team = model.team;
            entity.gender = model.gender;
            entity.division = model.division;
            entity.height_format = model.height_format;
            entity.weight_format = model.weight_format;
            entity.user_verified_dob = model.user_verified_dob;
            entity.aux1 = model.aux1;
            entity.other = model.other;
            entity.datastore = model.datastore;
            entity.st_api_key = model.st_api_key;
            entity.trainer_id = model.trainer_id;
            entity.app_key = model.app_key;
            entity.city = model.city;
            entity.province = model.province;
            entity.country = model.country;
            entity.created = model.created;
            entity.modified = DateTime.Now;
            
            await repository.UpdateAsync(entity);
           
            return Ok("data has been modified");
        }


        [HttpGet("{id}", Name = "GetUserByID")]
        public async Task<IActionResult> Get(long id)
        {
            var item = await repository.FindAsync(id);
            if (item == null)
                return NotFound();

            return Ok(item);

        }

        [HttpGet]
        [Route("GetUserByUserID/{userid}")]
        public async Task<IActionResult> GetUserByUserID(long userid)
        {


            var item = await repository.FindAsyncByUserID(userid);



            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        [Route("GetUserByParentUserID/{parentuserid}")]
        public async Task<IActionResult> GetUserByParentUserID(long parentuserid)
        {
            var item = await repository.FindAsyncByParentUserID(parentuserid);

            if (item == null)
                return NotFound();

            return Ok(item);
        }


        [HttpGet]
         [Route("GetByOptionalValues")]
        public async Task<IActionResult> GetByOptionalValues(
        [FromQuery] long? id, [FromQuery] long? userid, [FromQuery] long? parentuserid, 
           [FromQuery] long? organizationid, [FromQuery] long? masterid, [FromQuery] long? roleid,
           [FromQuery] long? statusid, [FromQuery] long? cityid, long? provinceid,
           [FromQuery] long? countryid, [FromQuery] DateTime? created

            )
        {


            var item = await repository.FindAsyncOptionalValue(id, userid, parentuserid, organizationid, masterid, roleid,
             statusid, cityid, provinceid,
             countryid, created);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}