using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Games
{
    public class GameTypesModel
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
