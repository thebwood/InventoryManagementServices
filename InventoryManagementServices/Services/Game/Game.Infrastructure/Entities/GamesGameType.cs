using System;
using System.Collections.Generic;

namespace Game.Infrastructure.Entities
{
    public partial class GamesGameType
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public Guid GameTypesId { get; set; }
    }
}
