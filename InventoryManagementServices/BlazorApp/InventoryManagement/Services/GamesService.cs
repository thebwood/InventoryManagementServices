using InventoryManagement.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class GamesService : BaseService
    {
        #region Games

        public async Task<List<GamesModel>> GetGames()
        {
            var baseURL = "http://localhost:5109/";
            return await this.GetAPIResult<List<GamesModel>>(baseURL, "api/games");
        }

        public async Task<GamesModel> GetGame(long gameId)
        {
            var baseURL = "http://localhost:5109/";
            return await this.GetAPIResult<GamesModel>(baseURL, "api/games/" + gameId.ToString());
        }


        public async Task<List<string>> SaveGame(GamesModel game)
        {
            var baseURL = "http://localhost:5109/";
            return await this.PostAPIResult<List<string>, GamesModel>(baseURL, "api/games/", game);

        }

        public async Task<List<GameSearchResultsModel>> SearchGames(GameSearchModel searchModel)
        {
            var baseURL = "http://localhost:5109/";
            return await this.PostAPIResult<List<GameSearchResultsModel>, GameSearchModel>(baseURL, "api/games/search", searchModel);
        }

        #endregion

        #region Game Ratings

        public async Task<List<GameRatingsModel>> GetGameRatings()
        {
            var baseURL = "http://localhost:5109/";
            return await this.GetAPIResult<List<GameRatingsModel>>(baseURL, "api/games/ratings");
        }

        #endregion

    }
}
