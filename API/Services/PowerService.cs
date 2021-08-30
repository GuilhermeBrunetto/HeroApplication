using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Services
{
    public class PowerService : IPowerService
    {
        private readonly DataContext _context;
        public PowerService(DataContext context)
        {
            _context = _context;
        }


        public void AddPowerAsync(int id, string name)
        {
            var power =  new Power{ PowerId = id, PowerName = name };
        

        }
    }
}