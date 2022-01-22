using InventoryManagement.Models.Inventory;
using InventoryManagement.Shared.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.Inventory
{
    public partial class InventoryList : CommonInventoryFunctions
    {
        #region Private Variables
        private List<InventorySearchResultsModel> _inventory;
        #endregion



        #region Blazor Events

        protected override async Task OnInitializedAsync()
        {
            await HandleSearch(new InventorySearchModel());
            if (_inventory == null)
                _inventory = new List<InventorySearchResultsModel>();
        }
        #endregion

        #region Events
        private async Task HandleSearch(InventorySearchModel searchModel)
        {
            _inventory = await this.Service.SearchInventory(searchModel);
        }
        private void AddInventory()
        {
            this.NavigationManager.NavigateTo("inventory/0");

        }
        #endregion
    }
}
