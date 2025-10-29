using System.Data;
using Techinical.Quala.Api.Models;
using Techinical.Quala.Api.Services;
using Technical_Test_Quala.Data;
using Technical_Test_Quala.Models;
using Dapper;

namespace Techinical.Quala.Api.Repositories
{
    public class userRepository : IuserRepository
    {
        private readonly DrapperContext _context;

        public userRepository(DrapperContext context)
        {
            _context = context;
        }

        public async Task<as_users?> GetByUser(string nameuser)
        {
            var query = "sp_Get_as_users_By_User";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<as_users>(
                    query,
                    new { nameuser },
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
