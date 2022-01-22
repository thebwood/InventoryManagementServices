using Game.API.Data;
using Game.API.Models;

namespace Game.API.Repositories.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Games> GetGames();
        Games GetGame(Guid? gameId);
        void SaveDetail(Games game);
        IEnumerable<GameRatings> GetGameRatings();
        List<GameSearchResultsModel> SearchGames(GameSearchModel searchRequest);

    }
}
