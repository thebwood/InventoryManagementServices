using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Inventory
{
    public class InventorySearchModel
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public Guid? ItemTypeId { get; set; }
    }
}
