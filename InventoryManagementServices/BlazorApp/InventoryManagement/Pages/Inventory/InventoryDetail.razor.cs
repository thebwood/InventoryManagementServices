using InventoryManagement.Models.Inventory;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Pages.Inventory
{
    public partial class InventoryDetail : CommonInventoryFunctions
    {
        #region Private Variables

        private EditContext _editContext;

        private InventoryItemsModel _inventory = new InventoryItemsModel();
        private List<ItemTypesModel> _itemTypes = new List<ItemTypesModel>();

        private Task<InventoryItemsModel> _inventoryTask;
        private Task<List<ItemTypesModel>> _itemTypesTask;

        #endregion

        #region Parameters
        [Parameter]
        public long InventoryId { get; set; } = 0;

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            _editContext = new EditContext(_inventory);
            if (InventoryId > 0)
            {
                _inventoryTask = this.Service.GetInventory(InventoryId);
            }
            _itemTypesTask = this.Service.GetItemTypes();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

                if (InventoryId > 0)
                {
                    await Task.WhenAll(_inventoryTask, _itemTypesTask);
                    _inventory = _inventoryTask.Result;
                    _itemTypes = _itemTypesTask.Result;
                }
                else
                {
                    await Task.WhenAll(_itemTypesTask);
                    _itemTypes = _itemTypesTask.Result;
                }

                this.StateHasChanged();
            }
        }

        #endregion

        #region Events

        private async Task SaveInventory()
        {
            if (_editContext.Validate())
            {
                var messages = await this.Service.SaveInventory(_inventory);
                if (messages.Count() == 0)
                {
                    this.NavigationManager.NavigateTo("inventory");
                }
            }
        }
        private void CancelSave()
        {
            this.NavigationManager.NavigateTo("inventory");
        }
        #endregion
    }
}
