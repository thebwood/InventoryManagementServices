using System;
using System.Collections.Generic;

namespace Game.Infrastructure.Entities
{
    public partial class GameGenre
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid GameGenreId { get; set; }
        public string? GenreDescription { get; set; }
    }
}
