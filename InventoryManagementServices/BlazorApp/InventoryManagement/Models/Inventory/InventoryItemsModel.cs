using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Inventory
{
    public class InventoryItemsModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Item Type is Required")]
        public int? ItemTypeId { get; set; }
    }
}
