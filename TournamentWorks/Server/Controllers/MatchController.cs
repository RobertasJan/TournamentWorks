using Microsoft.AspNetCore.Mvc;
using TournamentWorks.Domain.Games;
using TournamentWorks.Domain.Repository.Games;

namespace TournamentWorks.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _repository;
        public MatchController(IMatchRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Match match)
        {
            var response = await _repository.Add(match);
            return new JsonResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMatch([FromBody] Match match)
        {
            var response = await _repository.Update(match);
            return new JsonResult(response);
        }


        [HttpGet]
        [Route("{id:int}")]
        public Match Get([FromRoute] int id)
        {
            var match = _repository.Get(id);
            return match;
        }
    }
}
