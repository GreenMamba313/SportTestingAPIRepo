using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class CombinesRepository : ICombinesRepository
    {
        private readonly ApplicationDbContext context;

        public CombinesRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Combines> AddAsync(Combines item)
        {
            context.Combines.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Combines item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Combines.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Combines> FindAsync(long id)
        {

            return await context.Combines.FirstOrDefaultAsync(p => p.id == id);
        }


        public async Task<List<Combines>> FindAsyncByUserID(long userid)
        {

            return await context.Combines.Where(p => p.user_id == userid).ToListAsync();

        }

        public async Task<List<Combines>> FindAsyncBySportID(long sportid)
        {
            return await context.Combines.Where(p => p.sport_id == sportid).ToListAsync();
        }


        public async Task<List<Combines>> FindAsyncByCombineID(long combineid)
        {
            return await context.Combines.Where(p => p.combine_id == combineid).ToListAsync();
        }

        public async Task<List<Combines>> FindAsyncByLocationID(long locationid)
        {
            return await context.Combines.Where(p => p.location_id == locationid).ToListAsync();
        }
    }
}
