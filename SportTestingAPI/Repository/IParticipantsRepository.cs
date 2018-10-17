using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
    public interface IParticipantsRepository
    {
        Task<Participants> FindAsync(long id);
        Task<Participants> AddAsync(Participants item);
        Task UpdateAsync(Participants item);

        Task <List<Participants>> FindAsyncByUserID(long userid);
         List<Participants> FindAsyncByCombineID(long combineid);

        Task<List<Participants>> FindAsyncByBandID(string bandid);

    }
}