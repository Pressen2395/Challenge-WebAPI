using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengesController : ControllerBase
    {
        private readonly PlayerDBContext _context;

        public ChallengesController(PlayerDBContext context)
        {
            _context = context;
        }

        // GET: api/Challenges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Challenges>>> Getchallenges()
        {
            return await _context.challenges.ToListAsync();
        }

        // GET: api/Challenges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Challenges>> GetChallenges(int id)
        {
            var challenges = await _context.challenges.FindAsync(id);

            if (challenges == null)
            {
                return NotFound();
            }

            return challenges;
        }
        

        private bool ChallengesExists(int id)
        {
            return _context.challenges.Any(e => e.challengeId == id);
        }
    }
}
