using System;
using System.Collections.Generic;

namespace Movie.Infrastructure.Entities
{
    public partial class MovieRatings
    {
        public Guid Id { get; set; }
        public string Rating { get; set; }
        public int Age { get; set; }
    }
}
