using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext __context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext _context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            __context = _context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<HeroDto>> Register(RegisterDto registerDto)
        {
            if (await HeroExists(registerDto.Heroname)) return BadRequest("Hero name is taken");

            using var hmac = new HMACSHA512();

            var hero = new Hero
            {
                HeroName = registerDto.Heroname.ToLower(),
                // Encoding.... cryptographs the password given as parameter in order to be used on PasswordHash
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            __context.Heroes.Add(hero);
            await __context.SaveChangesAsync();

            return new HeroDto
            {
                Heroname = hero.HeroName,
                Token = _tokenService.CreateToken(hero)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<HeroDto>> Login(LoginDto loginDto)
        {
            var hero = await __context.Heroes.SingleOrDefaultAsync(x => x.HeroName == loginDto.Heroname);

            if (hero == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(hero.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != hero.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new HeroDto
            {
                Heroname = hero.HeroName,
                Token = _tokenService.CreateToken(hero)
            };    
        }

        private async Task<bool> HeroExists(string heroname)
        {
            return await __context.Heroes.AnyAsync(x => x.HeroName == heroname.ToLower());
        }
    }
}