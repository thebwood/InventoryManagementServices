using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models.Movies
{
    public class MoviesModel
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Required(ErrorMessage = "Movie Rating is Required")]
        public Guid? MovieRatingsId { get; set; }
        public int? Hours { get; set; }
        public int? Minutes { get; set; }
        public decimal? BoxOffice { get; set; }
        public Guid? MovieGenresId { get; set; }
    }
}
