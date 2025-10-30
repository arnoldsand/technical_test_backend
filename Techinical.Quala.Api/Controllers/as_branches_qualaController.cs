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
    [Authorize]
    public class as_branches_qualaController : ControllerBase
    {
        public readonly Ias_branch_qualaService _service;
        public readonly IencriptationService _encritp;
        

        public as_branches_qualaController(Ias_branch_qualaService service, IencriptationService encript)
        {
            _service = service;
            _encritp = encript;
        }

        [HttpGet]
        public async Task<IEnumerable<as_branch_qualaDTOs>> GetAllAsync()
        {
           // var cadena = _encritp.Encrypt("1234567");
            return await _service.GetAllAsync();
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<as_branch_quala>> GetByIdAsync(int code)
        {
            var branch = await _service.GetByIdAsync(code);
            if (branch == null)
                return NotFound();
            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync([FromBody] as_branch_quala branch)
        {
            var result = await _service.InsertAsync(branch);
            if (result > 0)
                return Ok(new { message = "Registro insertado correctamente." });
            return BadRequest(new { message = "No se pudo insertar el registro."});
        }

        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateAsync([FromBody] as_branch_quala branch)
        {            
            var result = await _service.UpdateAsync(branch);
            if (result > 0)
                return Ok(new { message = "Registro actualizado correctamente." });

            return NotFound("No se encontró el registro a actualizar.");
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteAsync(int code)
        {
            var result = await _service.DeleteAsync(code);
            if (result > 0)
                return Ok(new { message = "Registro eliminado correctamente." });

            return NotFound("No se encontró el registro a eliminar.");
        }     
    }
}
