using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Entities;

namespace TournamentSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentSiteContext _context;

        public TournamentController(TournamentSiteContext context)
        {
            _context = context;
        }

        // GET: api/Tournament
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournament()
        {
            return await _context.Tournament.ToListAsync();
        }

        // GET: api/Tournament/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _context.Tournament.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return tournament;
        }

        // PUT: api/Tournament/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        {
            if (id != tournament.TournamentId)
            {
                return BadRequest();
            }

            _context.Entry(tournament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tournament
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        {
            _context.Tournament.Add(tournament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTournament", new { id = tournament.TournamentId }, tournament);
        }

        // DELETE: api/Tournament/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _context.Tournament.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _context.Tournament.Remove(tournament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournament.Any(e => e.TournamentId == id);
        }
    }
}
