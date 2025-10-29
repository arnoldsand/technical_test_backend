using Techinical.Quala.Api.DTOs;

namespace Techinical.Quala.Api.Services
{
    public interface IuserService
    {
        Task<UserValidationModel> ValidateUser(string user, string password);
    }
}
