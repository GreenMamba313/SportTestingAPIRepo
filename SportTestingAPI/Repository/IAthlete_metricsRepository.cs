using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
   public interface IAthlete_metricsRepository
    {

        Task<Athlete_metrics> FindAsync(long id);
        Task<Athlete_metrics> AddAsync(Athlete_metrics item);
        Task UpdateAsync(Athlete_metrics item);



    }
}
