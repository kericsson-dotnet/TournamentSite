using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentSite.Core.Entities;
using TournamentSite.Core.Repositories;
using TournamentSite.Data.Data;

namespace TournamentSite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IUoW _UoW;

        public GameController(IUoW UoW)
        {
            _UoW = UoW;
        }

        // GET: api/Game
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGame()
        {
            var games = await _UoW.GameRepository.GetAllAsync();
            return Ok(games);
        }

        // GET: api/Game/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _UoW.GameRepository.GetAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        // PUT: api/Game/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.GameId)
            {
                return BadRequest();
            }

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

            return NoContent();
        }

        // POST: api/Game
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _UoW.GameRepository.Add(game);
            await _UoW.CompleteAsync();

            return CreatedAtAction("GetGame", new { id = game.GameId }, game);
        }

        // DELETE: api/Game/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _UoW.GameRepository.GetAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _UoW.GameRepository.Remove(game);
            await _UoW.CompleteAsync();

            return NoContent();
        }

        private async Task<bool> GameExists(int id)
        {
            return await _UoW.GameRepository.AnyAsync(id);
        }
    }
}
