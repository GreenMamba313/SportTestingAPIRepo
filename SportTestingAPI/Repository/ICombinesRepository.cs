using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
   public interface ICombinesRepository
    {

        Task<Combines> FindAsync(long id);
        Task<Combines> AddAsync(Combines item);
        Task UpdateAsync(Combines item);

        Task<List<Combines>> FindAsyncByUserID(long userid);
        Task<List<Combines>> FindAsyncBySportID(long sportid);

        Task<List<Combines>> FindAsyncByCombineID(long combineid);

        Task<List<Combines>> FindAsyncByLocationID(long locationid);
    }
}
