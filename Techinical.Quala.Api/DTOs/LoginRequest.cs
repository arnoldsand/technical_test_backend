using System.ComponentModel.DataAnnotations;

namespace Techinical.Quala.Api.DTOs
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
