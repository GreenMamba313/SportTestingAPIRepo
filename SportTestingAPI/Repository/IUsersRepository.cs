using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
    public interface IUsersRepository
    {

        Task<Users> FindAsync(long id);
        Task<Users> AddAsync(Users item);
        Task UpdateAsync(Users item);


        Task<List<Users>> FindAsyncByUserID(long userid);
        Task<List<Users>> FindAsyncByParentUserID(long parentuserid);

        Task<List<Users>> FindAsyncOptionalValue(
            long? id,long? userid, long? parentuserid,
            long? organizationid , long? masterid, long? roleid,
            long? statusid, long? cityid, long? provinceid,
            long? countryid, DateTime? created
            );

    }
}
