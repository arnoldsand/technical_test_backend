using System.Security.Cryptography;
using Techinical.Quala.Api.Repositories;
using Techinical.Quala.Api.DTOs;

namespace Techinical.Quala.Api.Services
{
    public class userService : IuserService
    {
        private readonly IuserRepository _repository;
        private readonly IencriptationService _encritacionService;

        public userService(IuserRepository repository, IencriptationService encritacionService)
        {
            _repository = repository;
            _encritacionService = encritacionService;
        }

        public async Task<UserValidationModel?> ValidateUser(string nameuser, string password)
        {           
            var user = await _repository.GetByUser(nameuser);           
            if (user == null)
            {
                return null;
            }                      
            string storedPassword = _encritacionService.Decrypt(user.password);                        
            if (storedPassword != password)
            {            
                return null;
            }
            return new UserValidationModel
            {
                Username = user.nameuser,
                Role = user.rol
            };
        }
    }
}
