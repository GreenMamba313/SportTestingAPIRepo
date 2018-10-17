using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class UsersRepository: IUsersRepository
    {
        private readonly ApplicationDbContext context;

        public UsersRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Users> AddAsync(Users item)
        {
            context.Users.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Users item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Users.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Users> FindAsync(long id) {

            return await context.Users.FirstOrDefaultAsync(p => p.id==id);
        }


        public async Task<List<Users>> FindAsyncByUserID(long userid)
        {

            return await context.Users.Where(p => p.user_id == userid).ToListAsync();

        }

        public async Task<List<Users>> FindAsyncByParentUserID(long userid)
        {

            return await context.Users.Where(p => p.parent_user_id == userid).ToListAsync();

        }


        public async Task<List<Users>> FindAsyncOptionalValue(long? id, long? userid, long? parentuserid,
            long? organizationid, long? masterid, long? roleid,
            long? statusid, long? cityid, long? provinceid,
            long? countryid, DateTime? created)
        {



            IQueryable<Users> query = context.Users;

            if (id.HasValue && id.Value > 0)
                query = query.Where(p => p.id == id);

            if (userid.HasValue && userid.Value > 0)
                query = query.Where(p => p.user_id == userid);

            if (parentuserid.HasValue && parentuserid.Value > 0)
                query = query.Where(p => p.parent_user_id == parentuserid);

            if (organizationid.HasValue && organizationid.Value > 0)
                query = query.Where(p => p.organization_id == organizationid);

            if (masterid.HasValue && masterid.Value > 0)
                query = query.Where(p => p.master_id == masterid);

            if (roleid.HasValue && roleid.Value > 0)
                query = query.Where(p => p.role_id == roleid);

            if (statusid.HasValue && statusid.Value > 0)
                query = query.Where(p => p.status_id == statusid);


            if (cityid.HasValue && cityid.Value > 0)
                query = query.Where(p => p.city_id == cityid);

            if (provinceid.HasValue && provinceid.Value > 0)
                query = query.Where(p => p.province_id == provinceid);

            if (created != null)
                query = query.Where((p =>
                                       p.created.Value.Year == created.Value.Year
                                    && p.created.Value.Month == created.Value.Month
                                    && p.created.Value.Day == created.Value.Day));



            return await query.ToListAsync();


            //IQueryable<Users> query = context.Users;

            //if (id.HasValue && id.Value > 0)
            //    query = query.Where(p => p.id == id);

            //if (userid.HasValue && userid.Value > 0)
            //    query = query.Where(p => p.user_id == userid);

            //if (parentuserid.HasValue && parentuserid.Value > 0)
            //    query = query.Where(p => p.parent_user_id == parentuserid);


            //return await query.ToListAsync();

            //return await context.Users.Where(
            //    p => p.id == id || (id == null || id == 0)

            //    && (p.parent_user_id == parentuserid || (parentuserid == null || parentuserid == 0))
            //    && (p.user_id == userid || (userid == null || userid == 0))

            //    && (p.organization_id == organizationid || (organizationid == null || organizationid == 0))
            //    && (p.master_id == masterid || (masterid == null || masterid == 0))
            //    && (p.role_id == roleid || (roleid == null || roleid == 0))

            //    && (p.status_id == statusid || (statusid == null || statusid == 0))
            //    && (p.city_id == cityid || (cityid == null || cityid == 0))
            //    && (p.province_id == provinceid || (provinceid == null || provinceid == 0))

            //    && (p.country_id == countryid || (countryid == null || countryid == 0))
            //    /*&& (DateTime.Compare(p.created.Value.Date ,created.Value.Date )==0 || created == null )*/

            //    && ((p.created.Value.Year == created.Value.Year
            //    && p.created.Value.Month == created.Value.Month
            //    && p.created.Value.Day == created.Value.Day) || created == null)

            //    ).ToListAsync();



        }

    }
}
