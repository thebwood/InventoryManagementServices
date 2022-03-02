using System;
using System.Collections.Generic;

namespace Movie.Infrastructure.Entities
{
    public partial class MovieFormats
    {
        public Guid Id { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? FormatId { get; set; }
        public string FormatName { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
