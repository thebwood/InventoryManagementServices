namespace Movie.Core.Models
{
    public class MovieSearchModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public Guid? MovieRatingsId { get; set; }
        public List<int> MovieGenreIds { get; set; }
    }
}
