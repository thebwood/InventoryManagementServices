namespace Movie.Core.Models
{
    public class MovieFormatsModel
    {
        public Guid Id { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? FormatId { get; set; }
        public string FormatName { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
