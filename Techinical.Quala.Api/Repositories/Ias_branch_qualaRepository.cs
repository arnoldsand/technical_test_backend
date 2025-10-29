using System.Collections.Generic;
using System.Threading.Tasks;
using Technical_Test_Quala.Models;

namespace Technical_Test_Quala.Repositories
{
    public interface Ias_branch_qualaRepository
    {
        Task<IEnumerable<as_branch_quala>> GetAllAsync();
        Task<as_branch_quala?> GetByIdAsync(int code);
        Task<int> InsertAsync (as_branch_quala branch);
        Task<int> UpdateAsync (as_branch_quala branch);
        Task<int> DeleteAsync (int code);
    }
}