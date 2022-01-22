using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Inventory
{
    public class InventorySearchModel
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public int? ItemTypeId { get; set; }
    }
}
