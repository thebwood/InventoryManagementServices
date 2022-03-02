using System;
using System.Collections.Generic;

namespace Game.Infrastructure.Entities
{
    public partial class GameType
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
