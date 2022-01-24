using InventoryManagement.Models.Games;
using InventoryManagement.Shared.BaseClasses;
using InventoryManagement.StateManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace InventoryManagement.Components.Games
{
    public partial class GameDetail : CommonGameFunctions, IDisposable
    {

        #region Private Variables

        private EditContext _editContext;

        private GamesModel _game = new GamesModel();
        private List<GameRatingsModel> _gameRatings = new List<GameRatingsModel>();

        #endregion

        #region Parameters

        [Parameter]
        public GameDetailState GameDetailStateManagement { get; set; }

        #endregion

        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            GameDetailStateManagement.HandleGameLoaded += GameLoaded;
            GameDetailStateManagement.HandleRatingsLoaded += RatingsLoaded;
        }

        protected override void OnParametersSet()
        {
            _editContext = new EditContext(_game);
        }

        public void Dispose()
        {
            GameDetailStateManagement.HandleGameLoaded -= GameLoaded;
            GameDetailStateManagement.HandleRatingsLoaded -= RatingsLoaded;
        }

        #endregion

        #region Events

        private async Task SaveGame()
        {
            if (_editContext.Validate())
            {
                await GameDetailStateManagement.SaveGame(_game);
            }
        }


        private void CancelSave()
        {
            GameDetailStateManagement.CancelSave();
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
