
using Game.Infrastructure.Entities;

namespace Game.Infrastructure.Repositories.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Games> GetGames();
        Games GetGame(Guid? gameId);
        void SaveDetail(Games game);
        IEnumerable<GameRatings> GetGameRatings();
        List<GameSearchResults> SearchGames(GameSearch searchRequest);

    }
}
