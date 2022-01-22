using InventoryManagement.Models.Games;
using InventoryManagement.Shared.BaseClasses;
using InventoryManagement.StateManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.Games
{
    public partial class Game : CommonGameFunctions, IDisposable
    {

        #region Private Variables

        private EditContext _editContext;
        private GameDetailState _gameDetailStateManagement;

        private GamesModel _game = new GamesModel();
        private List<GameRatingsModel> _gameRatings = new List<GameRatingsModel>();

        #endregion

        #region Parameters
        [Parameter]
        public long GameId { get; set; }

        #endregion

        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            _gameDetailStateManagement = new GameDetailState(Service);
            _gameDetailStateManagement.HandleGameLoaded += GameLoaded;
            _gameDetailStateManagement.HandleRatingsLoaded += RatingsLoaded;
            _gameDetailStateManagement.OnGameSavedSuccessfully += OnSaved;
            if (GameId > 0)
            {
                await _gameDetailStateManagement.LoadGame(GameId);
            }
            else
            {
                _game = new GamesModel();
            }
            await _gameDetailStateManagement.LoadRatings();
        }

        protected override void OnParametersSet()
        {
            _editContext = new EditContext(_game);
        }

        public void Dispose()
        {
            _gameDetailStateManagement.HandleGameLoaded -= GameLoaded;
            _gameDetailStateManagement.HandleRatingsLoaded -= RatingsLoaded;
            _gameDetailStateManagement.OnGameSavedSuccessfully -= OnSaved;
        }

        #endregion

        #region Events

        private async Task SaveGame()
        {
            if (_editContext.Validate())
            {
                await _gameDetailStateManagement.SaveGame(_game);
            }
        }


        private void OnSaved()
        {
            this.NavigationManager.NavigateTo("games");
        }

        private void CancelSave()
        {
            this.NavigationManager.NavigateTo("games");
        }

        private void RatingsLoaded(List<GameRatingsModel> ratings)
        {
            _gameRatings = new List<GameRatingsModel>();
            _gameRatings.Add(new GameRatingsModel()
            {
                Id = null,
                Rating = "Please select a rating",
                Age = 0
            });

            foreach (var rating in ratings)
            {
                _gameRatings.Add(rating);
            }

            StateHasChanged();
        }

        private void GameLoaded(GamesModel game)
        {
            _game = game;
            _editContext = new EditContext(_game);
            StateHasChanged();
        }

        #endregion
    }
}
