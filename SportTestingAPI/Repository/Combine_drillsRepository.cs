using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class Combine_drillsRepository : ICombine_drillsRepository
    {
        private readonly ApplicationDbContext context;

        public Combine_drillsRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Combine_drills> AddAsync(Combine_drills item)
        {
            context.Combine_drills.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Combine_drills item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Combine_drills.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Combine_drills> FindAsync(long id)
        {

            return await context.Combine_drills.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Combine_drills>> FindAsyncByDrillID(long drillid)
        {
            return await context.Combine_drills.Where(p => p.drill_id == drillid).ToListAsync();
        }

        public async Task<List<Combine_drills>> FindAsyncByCombineID(long combineid)
        {
            return await context.Combine_drills.Where(p => p.combine_id == combineid).ToListAsync();
        }
    }
}
