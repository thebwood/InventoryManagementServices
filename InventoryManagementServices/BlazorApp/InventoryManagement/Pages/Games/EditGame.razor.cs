using InventoryManagement.Models.Games;
using InventoryManagement.Shared.BaseClasses;
using InventoryManagement.StateManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace InventoryManagement.Pages.Games
{
    public partial class EditGame : CommonGameFunctions, IDisposable
    {

        #region Private Variables

        private GameDetailState _gameDetailStateManagement;

        private GamesModel _game = new GamesModel();
        private List<GameRatingsModel> _gameRatings = new List<GameRatingsModel>();

        #endregion

        #region Parameters
        [Parameter]
        public Guid GameId { get; set; }

        #endregion

        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            _gameDetailStateManagement = new GameDetailState(Service);
            _gameDetailStateManagement.OnGameSavedSuccessfully += OnSaved;
            _gameDetailStateManagement.OnCancelSave += OnCancelSave;
            await _gameDetailStateManagement.LoadGame(GameId);
            await _gameDetailStateManagement.LoadRatings();
        }

        public void Dispose()
        {
            _gameDetailStateManagement.OnGameSavedSuccessfully -= OnSaved;
            _gameDetailStateManagement.OnCancelSave -= OnCancelSave;
        }

        #endregion

        #region Events


        private void OnSaved()
        {
            NavigationManager.NavigateTo("games");
        }

        private void OnCancelSave()
        {
            NavigationManager.NavigateTo("games");
        }

        #endregion
    }
}
