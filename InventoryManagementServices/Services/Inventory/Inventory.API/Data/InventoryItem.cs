using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class InventoryItem
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ItemTypeId { get; set; }
    }
}
