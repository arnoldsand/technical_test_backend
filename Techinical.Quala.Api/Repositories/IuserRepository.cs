using Techinical.Quala.Api.Models;
using Techinical.Quala.Api.Services;

namespace Techinical.Quala.Api.Repositories
{
    public interface IuserRepository
    {
        Task<as_users?> GetByUser(string user);
    }
}
