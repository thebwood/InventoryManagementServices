﻿using System;
using System.Collections.Generic;

namespace Movie.API.Data
{
    public partial class MovieGenres
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid MovieGenreId { get; set; }
        public string GenreDescription { get; set; }
    }
}
