using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentWorks.Domain.Games
{
    public class Game
    {
        public int Id { get; set; }

        public int Team1Score { get; set; } = 0;
        public int Team2Score { get; set; } = 0;
        public GameResult Result { get; set; } = GameResult.Undetermined;

        public Match Match { get; set; }
    }
    public enum GameResult : byte
    {
        Team1Victory = 1,
        Team2Victory = 2,

        Undetermined = 0
    }
}
