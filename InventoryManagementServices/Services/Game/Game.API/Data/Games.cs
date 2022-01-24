using System;
using System.Collections.Generic;

namespace Game.API.Data
{
    public partial class Games
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid GameRatingsId { get; set; }
        public string Rating { get; set; }
    }
}
