using System;
using System.Collections.Generic;

namespace Game.API.Data
{
    public partial class GameTypes
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
