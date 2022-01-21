namespace Game.API.Repositories.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<Games> GetGames();
        Games GetGame(long gameId);
        void SaveDetail(Games game);
        IEnumerable<GameRatings> GetGameRatings();
        List<GameSearchResultsModel> SearchGames(GameSearchModel searchRequest);

    }
}
