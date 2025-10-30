using Techinical.Quala.Api.Repositories;
using Technical_Test_Quala.Models;

namespace Techinical.Quala.Api.Services
{
    public class as_currencyService : Ias_currencyService
    {
        private readonly Ias_currencyRepository _repository;

        public as_currencyService(Ias_currencyRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<as_currency>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
