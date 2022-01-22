using InventoryManagement.Models.Games;
using InventoryManagement.Shared.BaseClasses;
using InventoryManagement.StateManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.Games
{
    public partial class Games : CommonGameFunctions
    {
        #region Private Variables
        private GameSearchState _gameSearchStateManagement;
        #endregion



        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            _gameSearchStateManagement = new GameSearchState(this.Service);
            await SearchGames(new GameSearchModel());
        }
        #endregion

        #region Events

        private void AddGame()
        {
            this.NavigationManager.NavigateTo("games/0");

        }

        private async Task SearchGames(GameSearchModel searchModel)
        {
            await _gameSearchStateManagement.SearchGames(searchModel);
        }


        #endregion

    }
}
