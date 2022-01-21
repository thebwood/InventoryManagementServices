using System;
using System.Collections.Generic;

namespace Game.API.Data
{
    public partial class GamesGameTypes
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid GameTypesId { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
