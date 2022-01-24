using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Models
{
    public class MovieGenresModel
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid MovieGenreId { get; set; }
        public string GenreDescription { get; set; }
    }
}
