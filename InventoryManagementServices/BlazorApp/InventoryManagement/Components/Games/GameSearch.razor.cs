using InventoryManagement.Models.Games;
using InventoryManagement.Shared.BaseClasses;
using InventoryManagement.StateManagement;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.Components.Games
{
    public partial class GameSearch : CommonGameFunctions
    {
        #region Private Variables
        private GameSearchModel _searchModel = new GameSearchModel();
        private List<GameRatingsModel> _gameRatings = new List<GameRatingsModel>();
        #endregion

        #region Parameters

        [Parameter]
        public GameSearchState GameSearchStateManagement { get; set; }

        #endregion

        #region Blazor Events
        protected override async Task OnInitializedAsync()
        { 
            GameSearchStateManagement.HandleRatingsLoaded += RatingsLoaded;
            await GameSearchStateManagement.LoadRatings();

        }

        protected void Dispose()
        {
            GameSearchStateManagement.HandleRatingsLoaded -= RatingsLoaded;
        }

        #endregion


        #region Events

        private async Task SearchGame()
        {
            await GameSearchStateManagement.SearchGames(_searchModel);
        }
        private void ResetSearch()
        {
            _searchModel = new GameSearchModel();
        }

        private void RatingsLoaded(List<GameRatingsModel> gameRatings)
        {
            _gameRatings = gameRatings;
            StateHasChanged();
        }
        #endregion

    }
}
