using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class InventoryMovie
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public Guid MovieFormatId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieFormat { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsNew { get; set; }
        public bool IsDigital { get; set; }
        public bool? PurchaseDate { get; set; }
    }
}
