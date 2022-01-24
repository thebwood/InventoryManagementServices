using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.Models
{
    public class MoviesModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid MovieRatingsId { get; set; }
        public string Rating { get; set; }
        public int? Hours { get; set; }
        public int? Minutes { get; set; }
        public decimal? BoxOffice { get; set; }
    }
}
