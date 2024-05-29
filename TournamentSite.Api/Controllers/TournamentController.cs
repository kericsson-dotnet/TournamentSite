using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Dto;
using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;

namespace TournamentSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController(IUoW UoW, IMapper mapper) : ControllerBase
    {
        private readonly IUoW _UoW = UoW;
        private readonly IMapper _mapper = mapper;

        // GET: api/Tournament
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentDto>>> GetTournament([FromQuery] bool includeGames = false)
        {
            var tournaments = await _UoW.TournamentRepository.GetAllAsync(includeGames);

            if (includeGames)
            {
                return Ok(_mapper.Map<IEnumerable<TournamentDto>>(tournaments));
            }
            else
            {

                return Ok(_mapper.Map<IEnumerable<TournamentDtoNoGames>>(tournaments));
            }

        }

        // GET: api/Tournament/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentDto>> GetTournament(int id)
        {
            var tournament = await _UoW.TournamentRepository.GetAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            var tournamentDto = _mapper.Map<TournamentDto>(tournament);

            return Ok(tournamentDto);
        }

        // PUT: api/Tournament/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, TournamentDto tournamentDto)
        {
            // Get previous data and object
            var tournament = await _UoW.TournamentRepository.GetAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            // Map new data to original entry
            _mapper.Map(tournamentDto, tournament);

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

            return Ok(tournament);
        }

        // POST: api/Tournament
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TournamentDto>> PostTournament(TournamentDto tournamentDto)
        {

            var tournament = _mapper.Map<Tournament>(tournamentDto);
            _UoW.TournamentRepository.Add(tournament);

            try
            {
                await _UoW.CompleteAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500);
            }
            var resultDto = _mapper.Map<TournamentDto>(tournament);

            return CreatedAtAction("GetTournament", new { id = tournament.TournamentId }, resultDto);
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

            var resultDto = _mapper.Map<TournamentDto>(tournament);

            return Ok(resultDto);
        }

        private async Task<bool> TournamentExists(int id)
        {
            return await _UoW.TournamentRepository.AnyAsync(id);
        }
    }
}
