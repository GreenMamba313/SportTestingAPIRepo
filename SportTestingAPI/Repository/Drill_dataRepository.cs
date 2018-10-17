using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class Drill_dataRepository : IDrill_dataRepository
    {
        private readonly ApplicationDbContext context;

        public Drill_dataRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Drill_data> AddAsync(Drill_data item)
        {
            context.Drill_data.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Drill_data item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Drill_data.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Drill_data> FindAsync(long id)
        {

            return await context.Drill_data.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Drill_data>> FindAsyncByUserID(long userid)
        {

            return await context.Drill_data.Where(p => p.user_id == userid).ToListAsync();

        }

        public async Task<List<Drill_data>> FindAsyncBySportID(long sportid)
        {
            return await context.Drill_data.Where(p => p.sport_id == sportid).ToListAsync();
        }

        public async Task<List<Drill_data>> FindAsyncByDrillID(long drillid)
        {
            return await context.Drill_data.Where(p => p.drill_id == drillid).ToListAsync();
        }

        public async Task<List<Drill_data>> FindAsyncByCombineID(long combineid)
        {
            return await context.Drill_data.Where(p => p.combine_id == combineid).ToListAsync();
        }
    }
}
