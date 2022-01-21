using Game.API.Repositories.Interfaces;

namespace Game.API.Repositories
{
    public class GameRepository : IGameRepository
    {
        public Games GetGame(long gameId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameRatings> GetGameRatings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Games> GetGames()
        {
            throw new NotImplementedException();
        }

        public void SaveDetail(Games game)
        {
            throw new NotImplementedException();
        }

        public List<GameSearchResultsModel> SearchGames(GameSearchModel searchRequest)
        {
            throw new NotImplementedException();
        }
    }
}
