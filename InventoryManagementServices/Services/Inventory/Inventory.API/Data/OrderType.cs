using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class OrderType
    {
        public Guid Id { get; set; }
        public string OrderType1 { get; set; }
        public int? OrderRank { get; set; }
    }
}
