using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class InventoryCondition
    {
        public Guid Id { get; set; }
        public string Condition { get; set; }
        public int? OrderRank { get; set; }
    }
}
