using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Technical_Test_Quala.Data;
using Technical_Test_Quala.Models;

namespace Technical_Test_Quala.Repositories
{
    public class as_branch_qualaRepository: Ias_branch_qualaRepository
    {
        private readonly DrapperContext _context;

        public as_branch_qualaRepository(DrapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<as_branch_quala>> GetAllAsync()
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "sp_Get_as_branches_quala";
                return await connection.QueryAsync<as_branch_quala>(
                    query,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public async Task<as_branch_quala?> GetByIdAsync(int code)
        {
            var query = "sp_Get_as_branches_quala_By_Code";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<as_branch_quala>(
                    query,
                    new { code },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public Task<int> InsertAsync(as_branch_quala branch)
        {
            var query = "sp_Insert_as_branches_quala";
            using (var connection = _context.CreateConnection())
            {
                return connection.ExecuteAsync(
                    query,
                    branch,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public Task<int> UpdateAsync(as_branch_quala branch)
        {
            var query = "sp_Update_as_branches_quala";
            using (var connection = _context.CreateConnection())
            {
                return connection.ExecuteAsync(
                    query,
                    branch,
                    commandType: CommandType.StoredProcedure
                );
            }
        }


        public Task<int> DeleteAsync(int code)
        {
            var query = "sp_Delete_as_brances_quala";
            using (var connection = _context.CreateConnection())
            {
                return connection.ExecuteAsync(
                    query,
                    new { code },
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}