using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Techinical.Quala.Api.DTOs;
using Techinical.Quala.Api.Services;
using Technical_Test_Quala.Models;
using Technical_Test_Quala.Services;

namespace Technical_Test_Quala.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class as_currencyController : ControllerBase
    {
        public readonly Ias_currencyService _service;   


        public as_currencyController(Ias_currencyService service)
        {
            _service = service;            
        }

        [HttpGet]
        public async Task<IEnumerable<as_currency>> GetAllAsync()
        {           
            return await _service.GetAllAsync();
        }      
    }
}
