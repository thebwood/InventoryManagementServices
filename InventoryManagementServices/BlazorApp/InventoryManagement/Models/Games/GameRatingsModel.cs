using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Games
{
    public class GameRatingsModel
    {
        public Guid? Id { get; set; }
        public string Rating { get; set; }
        public int? Age { get; set; }

    }
}
