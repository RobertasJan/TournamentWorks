using Microsoft.AspNetCore.Mvc;
using TournamentWorks.Domain.Games;
using TournamentWorks.Domain.Repository.Games;

namespace TournamentWorks.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repository;
        public GameController(IGameRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> FinalizeGame([FromBody] Game game)
        {
            await _repository.Add(game);
            return Ok();
        }

    }
}
