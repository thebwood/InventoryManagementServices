using InventoryManagement.Models.Games;
using InventoryManagement.Shared.BaseClasses;
using InventoryManagement.StateManagement;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace InventoryManagement.Components.Games
{
    public partial class GamesGrid : CommonGameFunctions
    {
        #region Parameters
        
        [Parameter]
        public GameSearchState GameSearchStateManagement { get; set; }

        #endregion

        #region Private Variables
        private List<GameSearchResultsModel> _games;

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            GameSearchStateManagement.OnGamesSearched += GamesSearched;
            if (_games == null)
                _games = new List<GameSearchResultsModel>();

        }
        protected void Dispose()
        {
            GameSearchStateManagement.OnGamesSearched -= GamesSearched;
        }
        #endregion
        #region Events

        private void EditGame(Guid? gameId)
        {
            this.NavigationManager.NavigateTo("games/Edit/" + gameId.ToString());
        }

        private void GamesSearched(List<GameSearchResultsModel> games)
        {
            _games = games;
            StateHasChanged();
        }
        #endregion
    }
}
