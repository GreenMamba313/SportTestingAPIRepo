using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
  public  interface ICombine_drillsRepository
    {

        Task<Combine_drills> FindAsync(long id);
        Task<Combine_drills> AddAsync(Combine_drills item);
        Task UpdateAsync(Combine_drills item);

        Task<List<Combine_drills>> FindAsyncByDrillID(long drillid);
        Task<List<Combine_drills>> FindAsyncByCombineID(long combineid);

    }
}
