using Microsoft.EntityFrameworkCore;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportTestingAPI.Repository
{
    public class Combine_metricsRepository : ICombine_metricsRepository
    {
        private readonly ApplicationDbContext context;

        public Combine_metricsRepository(ApplicationDbContext context) { this.context = context; }

        public async Task<Combine_metrics> AddAsync(Combine_metrics item)
        {
            context.Combine_metrics.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Combine_metrics item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Combine_metrics.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Combine_metrics> FindAsync(long id)
        {

            return await context.Combine_metrics.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<List<Combine_metrics>> FindAsyncByCombineID(long combineid)
        {
            return await context.Combine_metrics.Where(p => p.combine_id == combineid).ToListAsync();
        }

        public async Task<List<Combine_metrics>> FindAsyncByAthleteID(long athleteid)
        {
            return await context.Combine_metrics.Where(p => p.athlete_id == athleteid).ToListAsync();
        }

        public async Task<List<Combine_metrics>> FindAsyncByAthleteMetricID(long athletemetricid)
        {
            return await context.Combine_metrics.Where(p => p.athlete_metric_id == athletemetricid).ToListAsync();
        }
    }
}
