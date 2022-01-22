using InventoryManagement.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class InventoryService : BaseService
    {
        public async Task<List<InventorySearchResultsModel>> SearchInventory(InventorySearchModel searchModel)
        {
            var baseURL = "https://localhost:44375/";
            return await this.PostAPIResult<List<InventorySearchResultsModel>, InventorySearchModel>(baseURL, "api/inventory/search", searchModel);
        }

        public async Task<InventoryItemsModel> GetInventory(long inventoryId)
        {
            var baseURL = "https://localhost:44375/";
            return await this.GetAPIResult<InventoryItemsModel>(baseURL, "api/inventory/" + inventoryId.ToString());
        }


        public async Task<List<string>> SaveInventory(InventoryItemsModel model)
        {
            var baseURL = "https://localhost:44375/";
            return await this.PostAPIResult<List<string>, InventoryItemsModel>(baseURL, "api/inventory/", model);
        }
        public async Task<List<ItemTypesModel>> GetItemTypes()
        {
            var baseURL = "https://localhost:44375/";
            return await this.GetAPIResult<List<ItemTypesModel>>(baseURL, "api/inventory/itemtypes");
        }

    }
}
