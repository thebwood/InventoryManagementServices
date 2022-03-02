using Game.Core.Models;

namespace Game.Core.Services.Interfaces
{
    public interface IGameService
    {
        List<string> SaveDetail(GamesModel game);
        IEnumerable<GamesModel> GetGames();
        GamesModel GetGame(Guid? gameId);
        IEnumerable<GameRatingsModel> GetGameRatings();
        List<GameSearchResultsModel> SearchGames(GameSearchModel searchRequest);
    }
}
