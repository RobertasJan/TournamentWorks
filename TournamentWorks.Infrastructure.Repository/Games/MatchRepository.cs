using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentWorks.Domain.Games;
using TournamentWorks.Domain.Repository.Games;

namespace TournamentWorks.Infrastructure.Repository.Games
{
    public class MatchRepository : IMatchRepository
    {
        private readonly TournamentContext _dbContext;
        public MatchRepository(TournamentContext context)
        {
            _dbContext = context;
        }
        public async Task<int> Add(Match match)
        {
            await _dbContext.Matches.AddAsync(match);
            await _dbContext.SaveChangesAsync();
            return match.Id;
        }

        public Match Get(int id)
        {
            return _dbContext.Matches.FirstOrDefault(x => x.Id == id);
        }

        public async Task<int> Update(Match match)
        {
        //    var dbMatch = Get(match.Id);
        //    dbMatch = match;
            _dbContext.Update(match);
            await _dbContext.SaveChangesAsync();
            return match.Id;
        }
    }
}
