using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Infrastructure.Entities
{
    public class GameSearch
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public Guid? GameRatingsId { get; set; }
        public List<Guid> GameTypeIds { get; set; }
    }
}
