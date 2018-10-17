using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
    public interface IDrillsRepository
    {

        Task<Drills> FindAsync(long id);
        Task<Drills> AddAsync(Drills item);
        Task UpdateAsync(Drills item);

        Task<List<Drills>> FindAsyncByUserID(long userid);
        Task<List<Drills>> FindAsyncBySportID(long sportid);

    }
}
