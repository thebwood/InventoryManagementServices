using System;
using System.Collections.Generic;

namespace Game.Infrastructure.Entities
{
    public partial class GamesGameFormat
    {
        public Guid Id { get; set; }
        public Guid? GameId { get; set; }
        public Guid? GameFormatId { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
