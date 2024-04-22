using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace sampleDotnetCoreApi.Api.Core.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        ApplicationDbContext _context;
        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var heros = _context.heroes
                .Include(e => e.Quests)
                .Select(e => new
                {
                    name = e.Name,
                    quests = e.Quests.Select(e => e.Name).ToList()
                });

            var h = _context.heroes
                .Where( e => e.Id == 1)
                .Select(e => new
                {
                    name = e.Name
                });

            return Ok(heros);
        }
    }
}