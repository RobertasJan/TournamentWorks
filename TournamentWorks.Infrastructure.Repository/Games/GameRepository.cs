using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentWorks.Domain.Games;
using TournamentWorks.Domain.Repository.Games;

namespace TournamentWorks.Infrastructure.Repository.Games
{
    public class GameRepository : IGameRepository
    {
        private readonly TournamentContext _dbContext;
        public GameRepository(TournamentContext context)
        {
            _dbContext = context;
        }

        public async Task Add(Game game)
        {
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();
        }
    }
}
