using System;
using System.Collections.Generic;

namespace Game.Infrastructure.Entities
{
    public partial class GameRatings
    {
        public Guid Id { get; set; }
        public string Rating { get; set; } = null!;
        public int Age { get; set; }
    }
}
