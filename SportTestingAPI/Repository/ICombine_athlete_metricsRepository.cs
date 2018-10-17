using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
   public interface ICombine_athlete_metricsRepository
    {

        Task<Combine_athlete_metrics> FindAsync(long id);
        Task<Combine_athlete_metrics> AddAsync(Combine_athlete_metrics item);
        Task UpdateAsync(Combine_athlete_metrics item);

        Task<List<Combine_athlete_metrics>> FindAsyncByCombineID(long combineid);
        Task<List<Combine_athlete_metrics>> FindAsyncByAthleteMetricID(long athletemetricid);

    }
}
