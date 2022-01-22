using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.People
{
    public class ActorModel
    {
        public Guid Identifier { get; set; } = Guid.NewGuid();
        public PeopleModel Person { get; set; }
    }
}
