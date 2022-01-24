using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class InventoryGame
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public Guid GameFormatId { get; set; }
        public string GameTitle { get; set; }
        public string GameFormat { get; set; }
        public Guid OwnerId { get; set; }
        public bool IsNew { get; set; }
        public bool IsDigital { get; set; }
        public bool? PurchaseDate { get; set; }
    }
}
