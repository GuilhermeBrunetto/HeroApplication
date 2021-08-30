using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Entities;

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