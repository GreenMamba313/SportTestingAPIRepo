using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class DrillsRepository : IDrillsRepository
    {
        private readonly ApplicationDbContext context;

        public DrillsRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Drills> AddAsync(Drills item)
        {
            context.Drills.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Drills item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Drills.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Drills> FindAsync(long id)
        {

            return await context.Drills.FirstOrDefaultAsync(p => p.id == id);
        }


        public async Task<List<Drills>> FindAsyncByUserID(long userid)
        {

            return await context.Drills.Where(p => p.user_id == userid).ToListAsync();

        }

        public async Task<List<Drills>> FindAsyncBySportID(long sportid)
        {
            return await context.Drills.Where(p => p.sport_id == sportid).ToListAsync();
        }
    }
}
