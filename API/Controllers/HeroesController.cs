using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class HeroesController : BaseApiController
    {
        private readonly DataContext _context;
        public HeroesController(DataContext context)
        {
            // gives access to the DB
            _context = context;
        }


        [HttpGet]
        [AllowAnonymous]
        // async Task<bla> makes the method asynchronous
        public async Task<ActionResult<IEnumerable<Hero>>> GetHeroes()
        {
            return await _context.Heroes.ToListAsync();            
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHero(int id)
        {  
            return await _context.Heroes.FindAsync(id);
        }

    }
}