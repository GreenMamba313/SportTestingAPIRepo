using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class Combine_athlete_metricsRepository : ICombine_athlete_metricsRepository
    {
        private readonly ApplicationDbContext context;

        public Combine_athlete_metricsRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Combine_athlete_metrics> AddAsync(Combine_athlete_metrics item)
        {
            context.Combine_athlete_metrics.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Combine_athlete_metrics item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Combine_athlete_metrics.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Combine_athlete_metrics> FindAsync(long id)
        {

            return await context.Combine_athlete_metrics.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Combine_athlete_metrics>> FindAsyncByCombineID(long combineid)
        {
            return await context.Combine_athlete_metrics.Where(p => p.combine_id == combineid).ToListAsync();
        }

        public async Task<List<Combine_athlete_metrics>> FindAsyncByAthleteMetricID(long athletemetricid)
        {
            return await context.Combine_athlete_metrics.Where(p => p.athlete_metric_id == athletemetricid).ToListAsync();
        }
    }
}
