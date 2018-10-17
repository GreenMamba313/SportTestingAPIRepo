using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class SportsRepository : ISportsRepository
    {
        private readonly ApplicationDbContext context;

        public SportsRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Sports> AddAsync(Sports item)
        {
            context.Sports.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Sports item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Sports.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Sports> FindAsync(long id) {

            return await context.Sports.FirstOrDefaultAsync(p => p.id==id);
        }
    }
}
