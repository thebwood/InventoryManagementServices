using System;
using System.Collections.Generic;

namespace Game.API.Data
{
    public partial class GamesGameFormats
    {
        public Guid Id { get; set; }
        public Guid? GameId { get; set; }
        public Guid? GameFormatId { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
