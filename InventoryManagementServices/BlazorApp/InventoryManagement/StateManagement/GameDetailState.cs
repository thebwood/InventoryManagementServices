using InventoryManagement.Models.Games;
using InventoryManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.StateManagement
{
    public class GameDetailState
    {
        #region Constructor

        public GameDetailState(GamesService gameService)
        {
            _gameService = gameService;
        }

        #endregion

        #region Private Variables

        private GamesService _gameService;

        #endregion

        #region Events

        public async Task SaveGame(GamesModel gamesModel)
        {
            var results = await _gameService.SaveGame(gamesModel);
            if (results.Count() > 0)
                OnError?.Invoke(results);
            else
                OnGameSavedSuccessfully?.Invoke();
        }
        public void CancelSave ()
        {
            OnCancelSave?.Invoke();
        }

        public async Task LoadRatings()
        {
            var results = await _gameService.GetGameRatings();
            HandleRatingsLoaded?.Invoke(results);
        }
        public async Task LoadGame(Guid? gameId)
        {
            var result = await _gameService.GetGame(gameId);
            HandleGameLoaded?.Invoke(result);
        }

        #endregion
        #region Actions

        public Action OnGameSavedSuccessfully { get; set; }
        public Action OnCancelSave { get; set; }
        public Action<List<GameRatingsModel>> HandleRatingsLoaded { get; set; }
        public Action<GamesModel> HandleGameLoaded { get; set; }
        public Action<List<string>> OnError { get; private set; }

        #endregion

    }
}
