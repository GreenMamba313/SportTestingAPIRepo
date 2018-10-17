using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
   public  interface ISportsRepository
    {
        Task<Sports> FindAsync(long id);
        Task<Sports> AddAsync(Sports item);
        Task UpdateAsync(Sports item);
    }
}
