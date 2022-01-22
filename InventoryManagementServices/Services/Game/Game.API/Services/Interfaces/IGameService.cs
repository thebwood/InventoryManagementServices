using Game.API.Data;
using Game.API.Models;

namespace Game.API.Services.Interfaces
{
    public interface IGameService
    {
        List<string> SaveDetail(GamesModel game);
        IEnumerable<Games> GetGames();
        Games GetGame(Guid? gameId);
        IEnumerable<GameRatings> GetGameRatings();
        List<GameSearchResultsModel> SearchGames(GameSearchModel searchRequest);

    }
}
