using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Movies
{
    public class MovieSearchResultsModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public Guid? MovieRatingsId { get; set; }
        public int? Hours { get; set; }
        public int? Minutes { get; set; }
        public decimal? BoxOffice { get; set; }
        public string MovieGenre { get; set; }
        public string MovieRating { get; set; }
    }
}
