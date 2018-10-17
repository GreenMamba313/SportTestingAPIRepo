using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
   public interface ICombine_metricsRepository
    {

        Task<Combine_metrics> FindAsync(long id);
        Task<Combine_metrics> AddAsync(Combine_metrics item);
        Task UpdateAsync(Combine_metrics item);

        Task<List<Combine_metrics>> FindAsyncByCombineID(long combineid);
        Task<List<Combine_metrics>> FindAsyncByAthleteID(long athleteid);

        Task<List<Combine_metrics>> FindAsyncByAthleteMetricID(long athletemetricid);
    }
}
