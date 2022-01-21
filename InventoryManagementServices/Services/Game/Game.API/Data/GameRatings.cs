using System;
using System.Collections.Generic;

namespace Game.API.Data
{
    public partial class GameRatings
    {
        public Guid Id { get; set; }
        public string Rating { get; set; } = null!;
        public int Age { get; set; }
    }
}
