using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentWorks.Domain.Games;

namespace TournamentWorks.Domain.Repository.Games
{
    public interface IMatchRepository
    {
        Match Get(int id);
        Task<int> Add(Match match);
        Task<int> Update(Match match);
    }
}
