using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
   public interface IDrill_dataRepository
    {

        Task<Drill_data> FindAsync(long id);
        Task<Drill_data> AddAsync(Drill_data item);
        Task UpdateAsync(Drill_data item);

        Task<List<Drill_data>> FindAsyncByUserID(long userid);
        Task<List<Drill_data>> FindAsyncBySportID(long sportid);

        Task<List<Drill_data>> FindAsyncByDrillID(long drillid);
        Task<List<Drill_data>> FindAsyncByCombineID(long combineid);
    }
}
