using System;
using System.Collections.Generic;

namespace Game.Infrastructure.Entities
{
    public partial class GameFormat
    {
        public Guid Id { get; set; }
        public string GameFormat1 { get; set; } = null!;
        public int? ReleaseYear { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string? ManufacturerName { get; set; }
    }
}
