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
    public class GameController(IUoW UoW, IMapper mapper) : ControllerBase
    {
        private readonly IUoW _UoW = UoW;
        private readonly IMapper _mapper = mapper;

        // GET: api/Game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetGame()
        {
            var games = await _UoW.GameRepository.GetAllAsync();
            var gamesDto = _mapper.Map<IEnumerable<GameDto>>(games);
            return Ok(gamesDto);
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            try
            {
                var game = await _UoW.GameRepository.GetAsync(id);
                var gameDto = _mapper.Map<GameDto>(game);
                return Ok(gameDto);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/Game/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, GameDto gameDto)
        {
            // Get previous data and object
            var game = await _UoW.GameRepository.GetAsync(id);

            if (game == null)
            {
                return NotFound("GameId not found");
            }

            // Map new data to original entry
            _mapper.Map(gameDto, game);

            _UoW.GameRepository.Update(game);

            try
            {
                await _UoW.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool exists = await GameExists(id);
                if (!exists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(game);
        }

        // POST: api/Game
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameDto>> PostGame(GameDto gameDto)
        {
            var tournament = await _UoW.TournamentRepository.GetAsync(gameDto.TournamentId);
            if (tournament == null)
            {
                return NotFound("TournamentId not found");
            }

            var game = _mapper.Map<Game>(gameDto);
            _UoW.GameRepository.Add(game);

            try
            {
                await _UoW.CompleteAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500);
            }

            var resultDto = _mapper.Map<GameDto>(game);

            return CreatedAtAction("GetGame", new { id = game.GameId }, resultDto);
        }

        // DELETE: api/Game/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _UoW.GameRepository.GetAsync(id);
            if (game == null)
            {
                return NotFound("GameId not found");
            }

            _UoW.GameRepository.Remove(game);
            await _UoW.CompleteAsync();

            var resultDto = _mapper.Map<GameDto>(game);

            return Ok(resultDto);
        }

        private async Task<bool> GameExists(int id)
        {
            return await _UoW.GameRepository.AnyAsync(id);
        }
    }
}
