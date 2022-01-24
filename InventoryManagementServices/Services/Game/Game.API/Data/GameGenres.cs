using System;
using System.Collections.Generic;

namespace Game.API.Data
{
    public partial class GameGenres
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid GameGenreId { get; set; }
        public string GenreDescription { get; set; }
    }
}
