using Technical_Test_Quala.Models;

namespace Techinical.Quala.Api.Repositories
{
    public interface Ias_currencyRepository
    {
        Task<IEnumerable<as_currency>> GetAllAsync();
    }
}
