using Microsoft.EntityFrameworkCore;
using TournamentWorks.Domain.Games;
using TournamentWorks.Domain.Players;
using TournamentWorks.Domain.Tournaments;

namespace TournamentWorks.Infrastructure
{
    public class TournamentContext : DbContext
    {
        public TournamentContext(DbContextOptions options) : base(options)
        {
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}