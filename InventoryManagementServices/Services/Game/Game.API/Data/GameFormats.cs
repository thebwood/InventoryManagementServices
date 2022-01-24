using System;
using System.Collections.Generic;

namespace Game.API.Data
{
    public partial class GameFormats
    {
        public Guid Id { get; set; }
        public string GameFormat1 { get; set; }
        public int? ReleaseYear { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
    }
}
