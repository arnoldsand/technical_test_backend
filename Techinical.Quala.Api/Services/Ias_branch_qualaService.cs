using Techinical.Quala.Api.DTOs;
using Technical_Test_Quala.Models;

namespace Technical_Test_Quala.Services
{
    public interface Ias_branch_qualaService
    {
        Task<IEnumerable<as_branch_qualaDTOs>> GetAllAsync();
        Task<as_branch_qualaDTOs?> GetByIdAsync(int code);
        Task<int> InsertAsync(as_branch_quala branch);
        Task<int> UpdateAsync(as_branch_quala branch);
        Task<int> DeleteAsync(int code);
    }
}
