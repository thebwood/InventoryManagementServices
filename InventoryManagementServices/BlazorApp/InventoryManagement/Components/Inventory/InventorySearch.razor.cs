using InventoryManagement.Models.Inventory;
using InventoryManagement.Shared.BaseClasses;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Components.Inventory
{
    public partial class InventorySearch : CommonInventoryFunctions
    {
        #region Private Variables
        private InventorySearchModel _searchModel = new InventorySearchModel();
        private List<ItemTypesModel> _itemTypes = new List<ItemTypesModel>();

        private Task<List<ItemTypesModel>> _itemTypesTask;

        #endregion

        #region Parameters

        [Parameter]
        public EventCallback<InventorySearchModel> OnSearchInventory { get; set; }

        #endregion

        #region Blazor Events

        protected override void OnInitialized()
        {
            _itemTypesTask = this.Service.GetItemTypes();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.WhenAll(_itemTypesTask);
                _itemTypes = _itemTypesTask.Result;

                this.StateHasChanged();
            }
        }
        #endregion


        #region Events

        private void SearchInventory()
        {
            this.ConsoleInfo(_searchModel);
            if (OnSearchInventory.HasDelegate)
            {
                OnSearchInventory.InvokeAsync(_searchModel);
            }
        }
        private void ResetSearch()
        {
            _searchModel = new InventorySearchModel();
        }
        #endregion
    }
}
