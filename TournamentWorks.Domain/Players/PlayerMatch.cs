using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentWorks.Domain.Games;

namespace TournamentWorks.Domain.Players
{
    public class PlayerMatch
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }

        public Team Team { get; set; }
    }

    public enum Team
    {
        Team1 = 1,
        Team2 = 2
    }
}
