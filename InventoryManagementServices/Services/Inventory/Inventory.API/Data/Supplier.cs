using System;
using System.Collections.Generic;

namespace Inventory.API.Data
{
    public partial class Supplier
    {
        public Guid Id { get; set; }
        public string Supplier1 { get; set; }
        public bool IsActive { get; set; }
    }
}
