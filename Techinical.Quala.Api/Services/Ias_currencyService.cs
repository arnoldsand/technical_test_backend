using Techinical.Quala.Api.Repositories;
using Technical_Test_Quala.Models;
using Technical_Test_Quala.Repositories;

namespace Techinical.Quala.Api.Services
{
    public interface Ias_currencyService
    {
        Task<IEnumerable<as_currency>> GetAllAsync();        
    }
}
