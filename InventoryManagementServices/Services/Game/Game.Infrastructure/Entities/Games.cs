using System;
using System.Collections.Generic;

namespace Game.Infrastructure.Entities
{
    public partial class Games
    {
        public Guid? Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid GameRatingsId { get; set; }
        public string? Rating { get; set; }
    }
}
