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
        Task<bool> InsertMatch(Match match);
    }
}
