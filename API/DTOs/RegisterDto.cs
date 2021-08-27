using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Heroname { get; set; }
        [Required]
        public string Password { get; set; }
    }
}