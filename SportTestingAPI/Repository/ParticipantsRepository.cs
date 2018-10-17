using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using SportTestingAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using SportTestingAPI.Dto;
using Microsoft.Extensions.Options;

namespace SportTestingAPI.Repository
{
    public class ParticipantsRepository : IParticipantsRepository
    {
        private readonly ApplicationDbContext context;
        private IConfiguration Configuration;
        private AppSettings AppSettings { get; set; }

        public ParticipantsRepository(ApplicationDbContext context, IOptions<AppSettings> settings)
        {
            this.context = context;
            AppSettings = settings.Value;
        }

        public async Task<Participants> AddAsync(Participants item)
        {
            context.Participants.Add(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(Participants item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            context.Participants.Update(item);
            await context.SaveChangesAsync();
        }


        public async Task<Participants> FindAsync(long id) {

            return await context.Participants.FirstOrDefaultAsync(p => p.id==id);
        }

        public async Task<List<Participants>> FindAsyncByUserID(long userid)
        {

            return await context.Participants.Where(p =>p.user_id== userid).ToListAsync();

        }

        public List<Participants> FindAsyncByCombineID(long CombineID)
        {
            IDbConnection db=null;
            try
            {
                string connectionString = AppSettings.DefaultConnection;


                 db = new SqlConnection(connectionString);

                String sql = "SELECT p.*,u.first_name,u.last_name,u.username FROM participants p LEFT JOIN users u on p.user_id=u.user_id where p.combine_id=" + CombineID;
                var data = db.Query<Participants, UsersDto, Participants>
                    (sql, (parti, user) => { parti.user = user; return parti; }, splitOn: "user_id");



                return data.ToList();
            }
            catch (Exception ex) { throw new Exception("error occurs due to " + ex.Message); }
            finally
            {
                db.Close();
                db.Dispose();
            }

            return null;
        }

        public async Task<List<Participants>> FindAsyncByBandID(String BandID)
        {

            return await context.Participants.Where(p => p.band_id == BandID).ToListAsync();

        }
    }
}
