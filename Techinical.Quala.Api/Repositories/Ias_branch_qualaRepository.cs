using System.Collections.Generic;
using System.Threading.Tasks;
using Technical_Test_Quala.Models;
using Techinical.Quala.Api.DTOs;

namespace Technical_Test_Quala.Repositories
{
    public interface Ias_branch_qualaRepository
    {
        Task<IEnumerable<as_branch_qualaDTOs>> GetAllAsync();
        Task<as_branch_qualaDTOs?> GetByIdAsync(int code);
        Task<int> InsertAsync (as_branch_quala branch);
        Task<int> UpdateAsync (as_branch_quala branch);
        Task<int> DeleteAsync (int code);
    }
}