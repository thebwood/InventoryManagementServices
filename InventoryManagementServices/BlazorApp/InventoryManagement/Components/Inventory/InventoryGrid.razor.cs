using InventoryManagement.Models.Inventory;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Components.Inventory
{
    public partial class InventoryGrid : CommonInventoryFunctions
    {
        #region Parameters

        [Parameter]
        public List<InventorySearchResultsModel> Models { get; set; }

        #endregion

        #region Events

        private void EditInventory(Guid? inventoryId)
        {
            this.NavigationManager.NavigateTo("inventory/" + inventoryId.ToString());
        }

        #endregion
    }
}
