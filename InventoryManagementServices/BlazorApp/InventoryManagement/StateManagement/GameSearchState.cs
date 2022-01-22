using InventoryManagement.Models.Games;
using InventoryManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.StateManagement
{
    public class GameSearchState
    {
        #region Constructor

        public GameSearchState(GamesService gameService)
        {
            _gameService = gameService;
        }

        #endregion

        #region Private Variables

        private GamesService _gameService;

        #endregion


        #region Events

        public async Task SearchGames(GameSearchModel searchModel)
        {
            var results = await _gameService.SearchGames(searchModel);
            OnGamesSearched?.Invoke(results);
        }
 
        public async Task LoadRatings()
        {
            var results = await _gameService.GetGameRatings();
            HandleRatingsLoaded?.Invoke(results);
        }
        #endregion


        #region Actions

        public Action<List<GameSearchResultsModel>> OnGamesSearched { get; set; }
        public Action<List<GameRatingsModel>> HandleRatingsLoaded { get; set; }
        #endregion
    }
}
