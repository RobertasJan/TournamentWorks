using TournamentWorks.Domain.Games;

namespace TournamentWorks.Domain.Repository.Games
{
    public interface IGameRepository
    {
        Task Add(Game game);
    }
}
