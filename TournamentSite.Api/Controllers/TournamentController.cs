using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;

namespace TournamentSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController(IUoW UoW) : ControllerBase
    {
        private readonly IUoW _UoW = UoW;

        // GET: api/Tournament
        [HttpGet]
        public async Task<IEnumerable<Tournament>> GetTournament()
        {
            // return await _tournamentRepository.GetAllAsync();
            return await _UoW.TournamentRepository.GetAllAsync();
        }

        // GET: api/Tournament/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _UoW.TournamentRepository.GetAsync(id);

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

            _UoW.TournamentRepository.Update(tournament);

            try
            {
                await _UoW.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool exists = await TournamentExists(id);
                if (!exists)
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
            _UoW.TournamentRepository.Add(tournament);
            await _UoW.CompleteAsync();

            return CreatedAtAction("GetTournament", new { id = tournament.TournamentId }, tournament);
        }

        // DELETE: api/Tournament/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _UoW.TournamentRepository.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _UoW.TournamentRepository.Remove(tournament);
            await _UoW.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> TournamentExists(int id)
        {
            return await _UoW.TournamentRepository.AnyAsync(id);
        }
    }
}
