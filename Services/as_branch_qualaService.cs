using Technical_Test_Quala.Repositories;
using Technical_Test_Quala.Models;

namespace Technical_Test_Quala.Services
{
    public class as_branch_qualaService : Ias_branch_qualaService
    {
        private readonly Ias_branch_qualaRepository _repository;

        public as_branch_qualaService(Ias_branch_qualaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<as_branch_quala>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<as_branch_quala?> GetByIdAsync(int code)
        {
            return _repository.GetByIdAsync(code);
        }

        public Task<int> InsertAsync(as_branch_quala branch)
        {
            return _repository.InsertAsync(branch);
        }

        public Task<int> UpdateAsync(as_branch_quala branch)
        {
            return _repository.UpdateAsync(branch);
        }

        public Task<int> DeleteAsync(int code)
        {
            return _repository.DeleteAsync(code);
        }
    }
}
