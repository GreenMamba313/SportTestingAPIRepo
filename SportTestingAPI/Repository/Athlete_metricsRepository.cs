using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class Athlete_metricsRepository : IAthlete_metricsRepository
    {
        private readonly ApplicationDbContext context;

        public Athlete_metricsRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Athlete_metrics> AddAsync(Athlete_metrics item)
        {
            context.Athlete_metrics.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Athlete_metrics item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Athlete_metrics.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Athlete_metrics> FindAsync(long id)
        {

            return await context.Athlete_metrics.FirstOrDefaultAsync(p => p.id == id);
        }
    }
}
