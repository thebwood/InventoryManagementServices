using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class Order
    {
        public Guid Id { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid OrderTypesId { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid InventoryConditionId { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
