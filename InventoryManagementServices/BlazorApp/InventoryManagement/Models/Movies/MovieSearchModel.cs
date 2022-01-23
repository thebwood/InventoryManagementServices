using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Movies
{
    public class MovieSearchModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public Guid? MovieRatingsId { get; set; }
        public List<Guid>? MovieGenreIds { get; set; }
    }
}
