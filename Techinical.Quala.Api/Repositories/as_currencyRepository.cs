using System.Data;
using Techinical.Quala.Api.DTOs;
using Technical_Test_Quala.Models;
using System.Threading.Tasks;
using Technical_Test_Quala.Data;
using Dapper;

namespace Techinical.Quala.Api.Repositories
{
    public class as_currencyRepository : Ias_currencyRepository
    {
        private readonly DrapperContext _context;

        public as_currencyRepository(DrapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<as_currency>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "sp_Get_as_currency";
                return await connection.QueryAsync<as_currency>(
                    query,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
